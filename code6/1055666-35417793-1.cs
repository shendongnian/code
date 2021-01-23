        private static volatile ImmutableSortedSet<DateTime> quarterEndCache =
            ImmutableSortedSet<DateTime>.Empty;
        private static volatile int counter; // test/verification purpose only
        public static DateTime GetNextQuarterEndDate(DateTime date)
        {
            var oneDayLater = date.AddDays(1.0);
            var fiveMonthsLater = date.AddMonths(5);
            var range = quarterEndCache.GetRangeBetween(oneDayLater, fiveMonthsLater);
            if (range.Any())
            {
                return range.First();
            }
            // Perform expensive calc here
            // -> Meaningless dummy computation for verification purpose only
            long x = Interlocked.Increment(ref counter);
            DateTime test = DateTime.FromFileTime(x);
            ImmutableExtensions.LockfreeUpdate(
                ref quarterEndCache,
                c => c.Add(test));
            return test;
        }
        
        [TestMethod]
        public void TestIt()
        {
            var tasks = Enumerable
                .Range(0, 100000)
                .Select(x => Task.Factory.StartNew(
                    () => GetNextQuarterEndDate(DateTime.Now)))
                .ToArray();
            
            Task.WaitAll(tasks);
            Assert.AreEqual(100000, counter);
        }
