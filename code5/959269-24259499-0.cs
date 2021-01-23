    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Splitter
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> numbers = Enumerable.Range(1, 25).ToList();
                int groupCount = 4;
                var lists = numbers.Groupem(groupCount, (e, i) =>
                {
                    // In what group do i wanna have this element.
                    int divider = numbers.Count / groupCount;
                    int overflow = numbers.Count % divider;
                    int index = (i - overflow) / divider;
                    return index < 0 ? 0 : index;
                });
                Console.WriteLine("numbers: {0}", numbers.ShowContent());
                Console.WriteLine("Parts");
                foreach (IEnumerable<int> list in lists)
                {
                    Console.WriteLine("{0}", list.ShowContent());
                }
            }
        }
        public static class EnumerableExtensions
        {
            private static List<T>[] CreateGroups<T>(int size)
            {
                List<T>[] groups = new List<T>[size];
                for (int i = 0; i < groups.Length; i++)
                {
                    groups[i] = new List<T>();
                }
                return groups;
            }
            public static void Each<T>(this IEnumerable<T> source, Action<T, int> action)
            {
                var i = 0;
                foreach (var e in source) action(e, i++);
            }
        
            public static IEnumerable<IEnumerable<T>> Groupem<T>(this IEnumerable<T> source, int groupCount, Func<T, int, int> groupPicker, bool failOnOutOfBounds = true)
            {
                if (groupCount <= 0) throw new ArgumentOutOfRangeException("groupCount", "groupCount must be a integer greater than zero.");
                List<T>[] groups = CreateGroups<T>(groupCount);
                source.Each((element, index) =>
                {
                    int groupIndex = groupPicker(element, index);
                    if (groupIndex < 0 || groupIndex >= groups.Length)
                    {
                        // When allowing some elements to fall out, set failOnOutOfBounds to false
                        if (failOnOutOfBounds)
                        {
                            throw new Exception("Some better exception than this");
                        }
                    }
                    else
                    {
                        groups[groupIndex].Add(element);
                    }
                });
                return groups;
            }
            public static string ShowContent<T>(this IEnumerable<T> list)
            {
                return "[" + string.Join(", ", list) + "]";
            }
        }
    }
