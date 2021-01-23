    namespace ConsoleApplication
    {
        using System;
        using System.Collections.Generic;
        using System.Threading;
        using MethodCache.Attributes;
        public class Program
        {
            private static DictionaryCache Cache { get; set; } 
            [Cache]
            private static int Calc(int b)
            {
                Thread.Sleep(5000);
                return b + 5;
            }
            private static void Main(string[] args)
            {
                Cache = new DictionaryCache();
                Console.WriteLine("Begin calc 1...");
                var v = Calc(5);
                // Will return the cached value
                Console.WriteLine("Begin calc 2...");
                v = Calc(5);
                Console.WriteLine("end calc 2...");
            }
        }
        public class DictionaryCache
        {
            public DictionaryCache()
            {
                Storage = new Dictionary<string, object>();
            }
            private Dictionary<string, object> Storage { get; set; }
            // Note: The methods Contains, Retrieve, Store must exactly look like the following:
            public bool Contains(string key)
            {
                return Storage.ContainsKey(key);
            }
            public T Retrieve<T>(string key)
            {
                return (T)Storage[key];
            }
            public void Store(string key, object data)
            {
                Storage[key] = data;
            }
        }
    }
