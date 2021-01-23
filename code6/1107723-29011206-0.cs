    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main( string[] args )
            {
                var intList = new List<int> { 1000, 9102, 123, 41, 10, 52, 24, 8, 26 };
                intList.ToArray()
                       .Sort( 0, 100, x => x > 27 );
            }
        }
    
        public static class Ex
        {
            public static void Sort<T>( this T[] input, int low, int high, Func<T, bool> predicate )
            {
                input.ToList()
                     .ForEach( x => predicate( x ) );
            }
        }
    }
