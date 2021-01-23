    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            void run()
            {
                var dict = new Dictionary<string, int>
                {
                    {"Key1", 1}, 
                    {"Key2", 2}, 
                    {"Key3", 3}, 
                    {"Key4", 2}, 
                    {"Key5", 4}
                };
                int valueToRemove = 2;
                var keysToRemove = (from element in dict
                                    where element.Value == valueToRemove
                                    select element.Key).ToList();
                foreach (var key in keysToRemove)
                    dict.Remove(key);
                foreach (var element in dict)
                    Console.WriteLine("Key = {0}, Value = {1}", element.Key, element.Value);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
