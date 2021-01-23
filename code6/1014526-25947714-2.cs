       using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication3
    {
        public class Program
        {
            public static void Main()
            {
                var dictionary = new Dictionary<int, Dictionary<string, string>>();
                var value = new Dictionary<string, string> { { "Key1", "Value1" }, { "Key2", "Value2" } };
                dictionary.Add(1, value);
    
                Dictionary<string, string> result;
    
    
                if (dictionary.TryGetValue(1, out result))
                {
                    foreach (var key in result.Keys)
                    {
                        Console.WriteLine("Key: {0} Value: b{1}", key, result[key]);
                    }
                }
            }
        }
    }
