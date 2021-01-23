    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace GetUniqueValues
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array1 = { 3, 4, 6, 2, 5, 11, 12, 20, 19, 18, 17, 15, 16, 1, 7, 8, 9, 10, 13, 14 };
                var values1 = GetUniqueValues<int>(array1, 3);
                foreach (var val in values1)
                {
                    Console.WriteLine(val);
                }
                string[] array2 = { "apple", "orange", "cherry", "melon", "grapefruit", "grapes", "peach", "watermelon" };
                var values2 = GetUniqueValues<string>(array2, 4);
                foreach (var val in values2)
                {
                    Console.WriteLine(val);
                }
            }
    
            public static T[] GetUniqueValues<T>(T[] array, int valuesCount)
            {
                var values = new List<T>();
    
                if (array != null && array.Length > 0 && valuesCount > 0)
                {                   
                    var distinctCount = array.Distinct().Count();
                    if (valuesCount > distinctCount)
                    {
                        valuesCount = distinctCount;
                    }
                    var random = new Random();
    
                    while(values.Count < valuesCount)
                    {
                        T val = array[random.Next(array.Length)];
                        if (!values.Contains(val))
                        {
                            values.Add(val);
                        }
                    }
                }
    
                return values.ToArray();
            }
        }
    }
