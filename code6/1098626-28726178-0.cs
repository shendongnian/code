    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace Sandbox
    {
        class Program
        {
            static void Main()
            {
                var array = new[] { 1, 6, 8, 3, 6, 2, 9, 0, 7, 3, 5 };
                var filtred = RecursiveFilter(array, i => i % 3 == 0);
                foreach (var item in filtred)
                    Console.WriteLine(item);
            }
            private static IEnumerable<T> RecursiveFilter<T>(IList<T> collection, Func<T, bool> predicate, int index = 0)
            {
                if (index < 0 || index >= collection.Count)
                    yield break;
                if (predicate(collection[index]))
                    yield return collection[index];
                foreach(var item in RecursiveFilter(collection, predicate, index + 1))
                    yield return item;
            }
        }
    }
