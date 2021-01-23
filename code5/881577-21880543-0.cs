    using System;
    using System.Collections.Generic;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            void test()
            {
                List<KeyValuePair<string, object>> lKVP = new List<KeyValuePair<string, object>>();
                List<string> lS = new List<string> { "s1", "s2" };
                string[] aS = {"a1", "a2"};
                lKVP.Add(new KeyValuePair<string, object>("String", "E92D8719-38A6-0000-961F-0E66FCB0A363"));
                lKVP.Add(new KeyValuePair<string, object>("Test", lS));
                lKVP.Add(new KeyValuePair<string, object>("IntNotEnumerable", 12345));
                lKVP.Add(new KeyValuePair<string, object>("Array", aS));
                foreach (KeyValuePair<string,object> kvp in lKVP)
                {
                    enumerate((dynamic) kvp.Value);
                }
            }
            static void enumerate<T>(List<T> list)
            {
                Console.WriteLine("Enumerating list of " + typeof(T).FullName);
                foreach (var item in list)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
            static void enumerate<T>(T[] array)
            {
                Console.WriteLine("Enumerating array of " + typeof(T).FullName);
                foreach (var item in array)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
            static void enumerate(object obj)
            {
                Console.WriteLine("Not enumerating type " + obj.GetType().FullName + " with value " + obj);
                Console.WriteLine();
            }
            static void Main(string[] args)
            {
                new Program().test();
            }
        }
    }
