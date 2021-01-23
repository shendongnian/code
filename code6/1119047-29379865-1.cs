    using System;
    using System.Diagnostics;
    namespace BenchTest
    {
        class Program
        {
            const int LoopCount = 1000000;
            const int AverageCount = 1000;
            static void Main(string[] args)
            {
                Console.WriteLine("Starting Benchmark");
                RunTest();
                Console.WriteLine("Finished Benchmark");
                Console.Write("Press any key to exit...");
                Console.ReadKey();
            }
            static void RunTest()
            {
                int cursorRow = Console.CursorTop; int cursorCol = Console.CursorLeft;
                long totalTime1 = 0; long totalTime2 = 0;
                long invalidOperationCount1 = 0; long invalidOperationCount2 = 0;
                for (int i = 0; i < AverageCount; i++)
                {
                    Console.SetCursorPosition(cursorCol, cursorRow);
                    Console.WriteLine("Running iteration: {0}/{1}", i + 1, AverageCount);
                    int[] indexArgs = RandomFill(LoopCount, int.MinValue, int.MaxValue);
                    int[] sizeArgs = RandomFill(LoopCount, 0, int.MaxValue);
                    totalTime1 += RunLoop(TestMethod1, indexArgs, sizeArgs, ref invalidOperationCount1);
                    totalTime2 += RunLoop(TestMethod2, indexArgs, sizeArgs, ref invalidOperationCount2);
                }
                PrintResult("Test 1", TimeSpan.FromTicks(totalTime1 / AverageCount), invalidOperationCount1);
                PrintResult("Test 2", TimeSpan.FromTicks(totalTime2 / AverageCount), invalidOperationCount2);
            }
            static void PrintResult(string testName, TimeSpan averageTime, long invalidOperationCount)
            {
                Console.WriteLine(testName);
                Console.WriteLine("    Average Time: {0}", averageTime);
                Console.WriteLine("    Invalid Operations: {0} ({1})", invalidOperationCount, (invalidOperationCount / (double)(AverageCount * LoopCount)).ToString("P3"));
            }
            static long RunLoop(Func<int, int, int> testMethod, int[] indexArgs, int[] sizeArgs, ref long invalidOperationCount)
            {
                Stopwatch sw = new Stopwatch();
                Console.Write("Running {0} sub-iterations", LoopCount);
                sw.Start();
                long startTickCount = sw.ElapsedTicks;
                for (int i = 0; i < LoopCount; i++)
                {
                    invalidOperationCount += testMethod(indexArgs[i], sizeArgs[i]);
                }
                sw.Stop();
                long stopTickCount = sw.ElapsedTicks;
                long elapsedTickCount = stopTickCount - startTickCount;
                Console.WriteLine(" - Time Taken: {0}", new TimeSpan(elapsedTickCount));
                return elapsedTickCount;
            }
            static int[] RandomFill(int size, int minValue, int maxValue)
            {
                int[] randomArray = new int[size];
                Random rng = new Random();
                for (int i = 0; i < size; i++)
                {
                    randomArray[i] = rng.Next(minValue, maxValue);
                }
                return randomArray;
            }
            static int TestMethod1(int index, int size)
            {
                return (index < 0 || index >= size) ? 1 : 0;
            }
            static int TestMethod2(int index, int size)
            {
                return ((uint)(index) >= (uint)(size)) ? 1 : 0;
            }
        }
    }
