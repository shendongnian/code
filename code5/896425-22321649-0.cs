    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            private void run()
            {
                int[] data = { 3, 4, 34, 22, 34, 3, 4, 4, 2, 7, 3, 8, 122, -1, -3, 1, 2 };
                int smallest = int.MaxValue;
                object locker = new object();
                Parallel.ForEach
                (
                    Partitioner.Create(0, data.Length),
                    () => int.MaxValue,
                    (subRange, loopState, threadLocalState, localData) =>
                    {
                        for (int i = subRange.Item1; i < subRange.Item2; i++)
                            localData = Math.Min(localData, data[i]);
                        return localData;
                    },
                    finalThreadLocalState =>
                    {
                        lock (locker)
                        {
                            smallest = Math.Min(smallest, finalThreadLocalState);
                        }
                    }
                );
                Console.WriteLine("Smallest = " + smallest);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
