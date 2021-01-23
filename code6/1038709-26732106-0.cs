    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        // This type contains two properties.
        // One is a plain List<Double>, the other is a type that itself contains Lists.
        public sealed class Container
        {
            public List<double> Doubles { get; set; }
            public Lists Lists { get; set; }
        }
        // This type contains two Lists.
        public sealed class Lists
        {
            public List<string> Strings { get; set; }
            public List<int> Ints { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                var lists = new Lists
                {
                    Strings = new List<string> {"A", "B", "C"}, 
                    Ints = new List<int> {1, 2, 3, 4, 5}
                };
                var container = new Container
                {
                    Doubles = new List<double> {1.1, 2.2, 3.3, 4.4},
                    Lists = lists
                };
                var items = FlattenLists(container);
                // This prints:
                //
                // 1.1
                // 2.2
                // 3.3
                // 4.4
                // A
                // B
                // C
                // 1
                // 2
                // 3
                // 4
                // 5
                foreach (var item in items)
                    Console.WriteLine(item);
            }
            // This recursively looks for all IList properties in the specified object and its subproperties.
            // It returns each element of any IList that it finds.
            public static IEnumerable<object> FlattenLists(object container)
            {
                foreach (var pi in container.GetType().GetProperties().Where(p => p.GetMethod.GetParameters().Length == 0))
                {
                    var prop = pi.GetValue(container);
                    if (typeof(IList).IsAssignableFrom(pi.PropertyType))
                    {
                        foreach (var item in (IList) prop)
                            yield return item;
                    }
                    foreach (var item in FlattenLists(prop))
                        yield return item;
                }
            }
        }
    }
