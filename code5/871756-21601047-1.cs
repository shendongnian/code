        public static DateTime NextDate(DateTime seed, int[] days)
        {
            if (Enumerable.Range(1, 31).Intersect(days).Any())  //Check to stop a very long running lookup!
            {
                return Enumerable.Range(0, int.MaxValue)
                    .Select(i => seed.AddDays(i))
                    .First(d => days.Contains(d.Day));
            }
            return seed;
        }
