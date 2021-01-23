        static IEnumerable<Entry> entries;
        
        static void Main(string[] args)
        {
            entries = ReadEntries();
            
            var tasks = new List<Task> {timeEntryCount,timeEntryCountWhereG1_equals_1,timeMetric2SumWhereG2_equals_1};
            tasks.ForEach(t => t.Start());
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Entry count took " + timeEntryCount.Result);
            Console.WriteLine("Entry count where G1==1 took " + timeEntryCountWhereG1_equals_1.Result);
            Console.WriteLine("Metric1 sum where G2==1 took " + timeMetric2SumWhereG2_equals_1.Result);
            Console.ReadLine();
        }
        static Task<TimeSpan> timeMetric2SumWhereG2_equals_1 = new Task<TimeSpan>(() =>
        {
            DateTime start = DateTime.Now;
            double sum = entries
                .Where(e => e.Grouping2 == 1)
                .Sum(e=>e.Metric2);
            Console.WriteLine("sum: " + sum);
            DateTime end = DateTime.Now;
            return end - start;
        },TaskCreationOptions.LongRunning);
        static Task<TimeSpan> timeEntryCountWhereG1_equals_1 = new Task<TimeSpan>(() =>
        {
            DateTime start = DateTime.Now;
            long count = entries
                .Where(e=>e.Grouping1==1)
                .Count();
            DateTime end = DateTime.Now;
            Console.WriteLine("countG1: " + count);
            return end - start;
        }, TaskCreationOptions.LongRunning);
        static Task<TimeSpan> timeEntryCount = new Task<TimeSpan>(() =>
        {
            DateTime start = DateTime.Now;
            long count = entries.Count();
            Console.WriteLine("CountAll: " + count);
            DateTime end = DateTime.Now;
            return end - start;
        }, TaskCreationOptions.LongRunning);
