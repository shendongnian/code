    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace RefreshTest {
        internal class Program {
            private static void Main(string[] args) {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < Environment.ProcessorCount; i++) {
                    Task task = Task.Run(() => Test());
                    tasks.Add(task);
                }
                tasks.ForEach(x => x.Wait());
                Console.WriteLine("Elapsed Milliseconds: {0}", watch.ElapsedMilliseconds);
                Console.ReadKey();
            }
            private static void Test() {
                for (int i = 0; i < 1000000; i++) {
                    var a = ContextCache.CustomerTypes;
                }
            }
        }
    }
