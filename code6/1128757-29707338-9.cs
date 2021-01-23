    public class TestClass
    {
        public static void TestBig()
        {
            var elapsed = TestBig(10000);
            Debug.WriteLine(elapsed.ToString());
        }
        static string GetName(int i)
        {
            return "ServiceDependence" + i.ToString();
        }
        public static TimeSpan TestBig(int count)
        {
            var serviceDependence = new Dictionary<string, List<string>>();
            for (int iItem = 0; iItem < count; iItem++)
            {
                var name = GetName(iItem);
                // Add several forward references.
                for (int iRef = iItem - 1; iRef > 0; iRef = iRef / 2)
                    serviceDependence.Add(name, GetName(iRef));
                // Add some backwards references.
                if (iItem > 0 && (iItem % 5 == 0))
                    serviceDependence.Add(name, GetName(iItem + 5));
            }
            // Add one backwards reference that will create some extremely long cycles.
            serviceDependence.Add(GetName(1), GetName(count - 1));
            List<List<string>> cycles;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                cycles = serviceDependence.FindCycles();
            }
            finally
            {
                stopwatch.Stop();
            }
            var elapsed = stopwatch.Elapsed;
            var averageLength = cycles.Average(l => (double)l.Count);
            var total = serviceDependence.Values.Sum(l => l.Count);
            foreach (var cycle in cycles)
            {
                serviceDependence[cycle[cycle.Count - 2]].Remove(cycle[cycle.Count - 1]);
            }
            Debug.Assert(serviceDependence.FindCycles().Count == 0);
            Console.WriteLine(string.Format("Time to find {0} cycles of average length {1} in {2} nodes with {3} total dependencies: {4}", cycles.Count, averageLength, count, total, elapsed));
            Console.ReadLine();
            System.Environment.Exit(0);
            return elapsed;
        }
    }
