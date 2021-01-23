    class Program
    {
        static void Main()
        {
            var all_paths = new List<List<Tuple<int, int, double>>>();
            const int n = 4000;
            for (int i = 0; i < n; i++)
            {
                var tuples = new List<Tuple<int, int, double>>();
                for (int j = 0; j < n; j++)
                {
                    tuples.Add(new Tuple<int, int, double>(i, j, (n + i)*j));
                }
                all_paths.Add(tuples);
            }
            var sw = Stopwatch.StartNew();
            var minList = MinList1(all_paths);
            sw.Stop();
            Console.WriteLine("{0} - {1}", minList[0], sw.Elapsed);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            var sw2 = Stopwatch.StartNew();
            var minList2 = MinList2(all_paths);
            sw2.Stop();
            Console.WriteLine("{0} - {1}", minList2[0], sw2.Elapsed);
        }
        private static List<Tuple<int, int, double>> MinList1(List<List<Tuple<int, int, double>>> all_paths)
        {
            return all_paths.Select(c => new {Value = c, Energy = c.Sum(p => p.Item3)})
                            .Aggregate((x, y) => x.Energy < y.Energy ? x : y).Value;
        }
        private static List<Tuple<int, int, double>> MinList2(List<List<Tuple<int, int, double>>> all_paths)
        {
            return all_paths.Aggregate((x, y) => x.Sum(i => i.Item3) < y.Sum(i => i.Item3) ? x : y);
        }
    }
