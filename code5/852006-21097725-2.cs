    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Sum: ");
                var sum = int.Parse(Console.ReadLine());
                var prefix = new[] { 1, 2, 3, 4, 5, 6 };
                var suffix = new[] { 0, 3, 2, 7, 7, 9, 12, 15 };
                foreach (var item in Solution(prefix, suffix, 1, 3, sum))
                {
                    Console.WriteLine("{0} = [ {1} ] + [ {2} ]", sum, string.Join(" + ", item.Item1.Select(T => prefix[T])), string.Join(" + ", item.Item2.Select(T => suffix[T])));
                }
                Console.WriteLine("Done here. Any key to close.");
                Console.ReadKey();
            }
            public static IEnumerable<Tuple<int[], int[]>> Solution(int[] one, int[] two, int minElementCount, int maxElementCount, int sum)
            {
                if (one.Length < minElementCount || two.Length < minElementCount)
                {
                    throw new Exception("Nah.");
                }
                var cacheOne = new Dictionary<int, List<int[]>>();
                var cacheTwo = new Dictionary<int, List<int[]>>();
                var result = new List<Tuple<int[], int[]>>();
                for (int countInOne = minElementCount; countInOne <= Math.Min(one.Length, maxElementCount); countInOne++)
                {
                    for (int countInTwo = minElementCount; countInTwo <= Math.Min(two.Length, maxElementCount); countInTwo++)
                    {
                        List<int[]> permutationsOne;
                        List<int[]> permutationsTwo;
                        if (!cacheOne.TryGetValue(countInOne, out permutationsOne))
                        {
                            permutationsOne = cacheOne[countInOne] = PermutationsIndices(one, countInOne).ToList();
                        }
                        if (!cacheTwo.TryGetValue(countInTwo, out permutationsTwo))
                        {
                            permutationsTwo = cacheTwo[countInTwo] = PermutationsIndices(two, countInTwo).ToList();
                        }
                        foreach (var permutationOne in permutationsOne)
                        {
                            var sumOne = permutationOne.Select(T => one[T]).Sum();
                            if (sumOne <= sum)
                            {
                                foreach (var permutationTwo in permutationsTwo)
                                {
                                    if ((sumOne + permutationTwo.Select(T => two[T]).Sum() == sum))
                                    {
                                        yield return Tuple.Create(permutationOne, permutationTwo);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            public static IEnumerable<int[]> PermutationsIndices<T>(this T[] e, int count)
            {
                if (count > e.Length)
                {
                    throw new Exception("Nah.");
                }
                return TraverseArray(e, new Stack<int>(), 0, count - 1);
            }
            public static IEnumerable<int[]> TraverseArray<T>(T[] array, Stack<int> stack, int index, int iterations)
            {
                for (int i = index; i < array.Length - iterations; i++)
                {
                    stack.Push(i);
                    if (iterations == 0)
                    {
                        yield return stack.Reverse().ToArray();
                    }
                    else
                    {
                        foreach (int[] item in TraverseArray(array, stack, i + 1, iterations - 1))
                        {
                            yield return item;
                        }
                    }
                    stack.Pop();
                }
            }
        }
    }
