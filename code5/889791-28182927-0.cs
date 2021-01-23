    using System.Linq;
    using System.Collections.Generic;
    using System;
    using System.Globalization;
    using System.Diagnostics;
    using System.Collections;
    namespace OrisNumbers
    {
        public static class IEnumeratorExtensions
        {
            public static IEnumerable<T> AsIEnumerable<T>(this IEnumerator iterator)
            {
                while (iterator.MoveNext())
                {
                    yield return (T)iterator.Current;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var s = "foo  bar mañana mañana" ;
                Debug.WriteLine(s);
                Debug.WriteLine(string.Join("", StringInfo.GetTextElementEnumerator(s.Normalize()).AsIEnumerable<string>().Reverse()));
                Console.Read();
            }
        }
    }
