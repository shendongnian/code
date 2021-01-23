lock list: 2,162s
ConcurrentBag: 7,264s
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class Test
    {
        public const int NumOfTasks = 4;
        public const int Cycles = 1000 * 1000 * 4;
    
        public static void Main()
        {
            var list = new List<int>();
            var bag = new ConcurrentBag<int>();
    
            Profile("lock list", () => { lock (list) list.Add(1); });
            Profile("ConcurrentBag", () => bag.Add(1));
        }
    
        public static void Profile(string label, Action work)
        {
            var s = new Stopwatch();
            s.Start();
    
            List<Task> tasks = new List<Task>();
    
            for (int i = 0; i < NumOfTasks; ++i)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < Cycles; ++j)
                    {
                        work();
                    }
                }));
            }
    
            Task.WaitAll(tasks.ToArray());
    
            Console.WriteLine(string.Format("{0}: {1:F3}s", label, s.Elapsed.TotalSeconds));
        }
    }
