using System;
using System.Collections.Generic;

namespace SteelHeartTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            var collection = new List<float> { 5, 325.1f, -7, 46.8f, 1.000f, 98, -999999.1f, 34.7f, 12345, 4, 9, 0.00f, 0, -8.5f };

            // Целые числа: 5, -7, 1 (1.000 я взял как целое число), 98, 12345, 4, 9, 0, 0
            // Сумма должна быть равна 12455

            // Сортировка с помощью Quick Sort
            QuickSort(collection, 0, collection.Count - 1);

            // Сумма всех целых элементов коллекции
            foreach (float f in collection) {
                if (f == Math.Floor(f))
                {
                    sum += (int)f;
                }
            }

            Console.WriteLine("Отсортированные элементы коллекции: ");
            foreach (float f in collection)
            {
                Console.Write($"{ f }   ");
            }

            Console.WriteLine($"\n \nСумма целых элементов коллекции равна: { sum }");
            Console.ReadKey();


            void QuickSort(List<float> list, int start, int end)
            {
                if (start >= end) // если дошли до конца, останавливаем ф-ию
                    return;

                // Получаем опорную точку
                int pivot = Divide(list, start, end);
                // Запускаем рекурсию с двумя частями колекции
                QuickSort(list, start, pivot - 1);
                QuickSort(list, pivot + 1, end);
            }

            int Divide(List<float> list, int start, int end)
            {
                int marker = start; // разделяет на левую и правую часть
                for (int i = start; i < end; i++)
                {
                    if (list[i] < list[end]) // list[end] – опорный элемент
                    {
                        (list[marker], list[i]) = (list[i], list[marker]); // меняем местами
                        marker += 1;
                    }
                }
                // помещаем опорный элемент (list[end]) между левой и правой частью 
                (list[marker], list[end]) = (list[end], list[marker]);

                return marker;
            }
        }
    }
}
