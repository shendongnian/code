    using System;
    using System.Collections.Generic;
    
    static class Program
    {
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5, 5, 5, 5, 1,
                         5, 5, 51, 5, 5, 12, 5, 5, 5 };
            foreach(var block in nums.FindBlocks())
            {
                Console.WriteLine(
                    "From index {0}, value {1} repeated {2} time(s)",
                    block.Item1, block.Item2, block.Item3);
            }
        }
        public static IEnumerable<Tuple<int, T,int>> FindBlocks<T>(
                  this IEnumerable<T> source)
        {
            var eq = EqualityComparer<T>.Default;
            using(var iter = source.GetEnumerator())
            {
                if(iter.MoveNext())
                {
                    T last = iter.Current;
                    int startIndex = 0, count = 1, index = 1;
                    while(iter.MoveNext())
                    {
                        var cur = iter.Current;
                        if(eq.Equals(last,cur))
                        {
                            count++;
                        }
                        else
                        {
                            if(count >= 2)
                            {
                                yield return Tuple.Create(startIndex, last, count);
                            }
                            count = 1;
                            last = cur;
                            startIndex = index;
                        }
                        index++;
                    }
                    if (count >= 2)
                    {
                        yield return Tuple.Create(startIndex, last, count);
                    }
                }
            }
        }
    }
