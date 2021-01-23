    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<int> a = Enumerable.Range(1, 3);
                IEnumerable b = a;
                IEnumerable<double> c = b.SelectTimesPi();
                foreach (var x in c)
                {
                    Console.WriteLine(x);
                }
                Console.ReadLine();
            }
        }
        static class Extensions
        {
            public static IEnumerable<double> SelectTimesPi(this IEnumerable source)
            {
                return source
                    .Cast<dynamic>()
                    .Select(x => Math.PI * x)
                    .Cast<double>();
            }
        }
    }
