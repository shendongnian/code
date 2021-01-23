    using System;
    using System.Collections.Generic;
    
    namespace GetUniqueValues
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = { 3, 4, 6, 2, 0, 5, 11, 12, 20, 19, 18, 17, 15, 16, 1, 7, 8, 9, 10, 13, 14 };
                var values = GetUniqueValues<int>(array, 3);
    
                foreach(var val in values)
                {
                    Console.WriteLine(val);
                }
            }
    
            public static T[] GetUniqueValues<T>(T[] array, int valuesCount)
            {
                var random = new Random();
                var values = new List<T>();
    
                if (array.Length > 0 && valuesCount > 0)
                {
                    if (valuesCount > array.Length)
                    {
                        valuesCount = array.Length;
                    }
    
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
