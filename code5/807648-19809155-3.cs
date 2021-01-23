    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TypedWhereExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = Enumerable.Range(0, 1000);
                var typedWhere1 = data.TypedWhere(x => x % 2 == 0);
                var typedWhere2 = typedWhere1.TypedWhere(x => x % 3 == 0);
                var result = typedWhere2.Take(10).ToList();  //Works like usual Linq
    
                //But returns additional data
                Console.WriteLine("Result: " + string.Join(",", result));
                Console.WriteLine("Typed Where 1 Skipped: " + typedWhere1.Skipped);
                Console.WriteLine("Typed Where 1 Returned: " + typedWhere1.Returned);
                Console.WriteLine("Typed Where 2 Skipped: " + typedWhere2.Skipped);
                Console.WriteLine("Typed Where 2 Returned: " + typedWhere2.Returned);
                Console.ReadLine();
    
                //Result: 0,6,12,18,24,30,36,42,48,54
                //Typed Where 1 Skipped: 27
                //Typed Where 1 Returned: 28
                //Typed Where 2 Skipped: 18
                //Typed Where 2 Returned: 10
            }
        }
    
        public static class MyLINQ
        {
            public static TypedWhereEnumerable<T> TypedWhere<T>
                (this IEnumerable<T> source, Func<T, bool> filter)
            {
                return new TypedWhereEnumerable<T>(source, filter);
            }
        }
    
        public class TypedWhereEnumerable<T> : IEnumerable<T>
        {
            IEnumerable<T> source;
            Func<T, bool> filter;
    
            public int Skipped { get; private set; }
            public int Returned { get; private set; }
    
            public TypedWhereEnumerable(IEnumerable<T> source, Func<T, bool> filter)
            {
                this.source = source;
                this.filter = filter;
            }
    
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                foreach (var o in source)
                    if (filter(o)) { Returned++; yield return o; }
                    else Skipped++;
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                foreach (var o in source)
                    if (filter(o)) { Returned++; yield return o; }
                    else Skipped++;
            }
        }
    }
