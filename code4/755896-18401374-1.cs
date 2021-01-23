    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Test
        {
            public string FilePath;
        }
        class Program
        {
            private void run()
            {
                int count = 1000000;
                List<Test> list = new List<Test>(count);
                for (int i = 0; i < count; ++i)
                    list.Add(new Test{ FilePath = i.ToString()});
                string target = (count-1).ToString();
                for (int trial = 0; trial < 4; ++trial)
                {
                    Action viaFindIndex =
                    (
                        () =>
                        {
                            int index = list.FindIndex(x => (x != null) && (x.FilePath == target));
                        }
                    );
                    Action viaLinq =
                    (
                        () =>
                        {
                            int index = list.Select((x, i) => new { Item = x, Index = i })
                            .First(x => (x != null) && (x.Item.FilePath == target))
                            .Index;
                        }
                    );
                    viaFindIndex.TimeThis("Via FindIndex()", 100);
                    viaLinq.TimeThis("Via Linq", 100);
                }
            }
            private static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void TimeThis(this Action action, string title, int count = 1)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    action();
                Console.WriteLine("Calling {0} {1} times took {2}", title, count, sw.Elapsed);
            }
        }
    }
