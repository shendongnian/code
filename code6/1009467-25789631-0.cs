    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        public class Group
        {
            public string Name
            {
                get;
                set;
            }
        }
    
        internal static class Program
        {
            static void Main()
            {
                int dummy = 0;
                List<Group> groups = new List<Group>();
                for (int i = 0; i < 10000; i++)
                {
                    var group = new Group();
                    group.Name = i + "asdasdasd";
                    groups.Add(group);
                }
                Stopwatch stopwatch = new Stopwatch();
                for (int outer = 0; outer < 4; ++outer)
                {
                    stopwatch.Restart();
                    foreach (var group in groups)
                        dummy += TestWhere(groups, x => x.Name == group.Name).Count();
                    Console.WriteLine("Using TestWhere(): " + stopwatch.ElapsedMilliseconds);
                    stopwatch.Restart();
                    foreach (var group in groups)
                        dummy += TestCount(groups, x => x.Name == group.Name);
                    Console.WriteLine("Using TestCount(): " + stopwatch.ElapsedMilliseconds);
                    stopwatch.Restart();
                    foreach (var group in groups)
                        dummy += TestListCount(groups, x => x.Name == group.Name);
                    Console.WriteLine("Using TestListCount(): " + stopwatch.ElapsedMilliseconds);
                }
                Console.WriteLine("Total = " + dummy);
            }
            public static int TestCount<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                int count = 0;
                foreach (TSource element in source)
                {
                    if (predicate(element)) 
                        count++;
                }
     
                return count;
            }
            public static int TestListCount<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                return testListCount((List<TSource>) source, predicate);
            }
            private static int testListCount<TSource>(List<TSource> source, Func<TSource, bool> predicate)
            {
                int count = 0;
                foreach (TSource element in source)
                {
                    if (predicate(element))
                        count++;
                }
                return count;
            }
            public static IEnumerable<TSource> TestWhere<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
            {
                return new WhereListIterator<TSource>((List<TSource>)source, predicate);
            }
        }
        class WhereListIterator<TSource>: Iterator<TSource>
        {
            readonly Func<TSource, bool> predicate;
            List<TSource>.Enumerator enumerator;
            public WhereListIterator(List<TSource> source, Func<TSource, bool> predicate)
            {
                this.predicate = predicate;
                this.enumerator = source.GetEnumerator();
            }
            public override bool MoveNext()
            {
                while (enumerator.MoveNext())
                {
                    TSource item = enumerator.Current;
                    if (predicate(item))
                    {
                        current = item;
                        return true;
                    }
                }
                Dispose();
                return false;
            }
        }
        abstract class Iterator<TSource>: IEnumerable<TSource>, IEnumerator<TSource>
        {
            internal TSource current;
            public TSource Current
            {
                get
                {
                    return current;
                }
            }
            public virtual void Dispose()
            {
                current = default(TSource);
            }
            public IEnumerator<TSource> GetEnumerator()
            {
                return this;
            }
            public abstract bool MoveNext();
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
