    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        /// <summary>
        /// How do you find the duplicate number on a given integer array?
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
    
                Dictionary<int, int> duplicates = FindDuplicate(array);
    
                Display(duplicates);
    
                Console.ReadLine();
            }
    
            private static Dictionary<T, int> FindDuplicate<T>(IEnumerable<T> source)
            {
                HashSet<T> set = new HashSet<T>();
                Dictionary<T, int> duplicates = new Dictionary<T, int>();
    
                foreach (var item in source)
                {
                    if (!set.Add(item))
                    {
                        if (duplicates.ContainsKey(item))
                        {
                            duplicates[item]++;
                        }
                        else
                        {
                            duplicates.Add(item, 2);
                        }
                    }
                }
    
                return duplicates;
            }
    
            private static void Display(Dictionary<int, int> duplicates)
            {
                foreach (var item in duplicates)
                {
                    Console.WriteLine($"{item.Key}:{item.Value}");
                }
            }
        }
    }
