            DateTime twoDaysAgo = DateTime.Today.AddDays(-2);
            DateTime monthAway = DateTime.Today.AddMonths(1);
            List<DateTime> checkDates = new List<DateTime>
            { new DateTime(2011, 11, 3), new DateTime(2011, 12, 5), new DateTime(2011, 12, 6), new DateTime(2011, 11, 2) };
            checkDates = checkDates.Select(x => new DateTime(DateTime.Today.Year, x.Month, x.Day)).ToList();
            var bdays = from p in checkDates
                        where (p >= twoDaysAgo && p <= monthAway) ||
                              (p>= twoDaysAgo.AddYears(-1) && p <= monthAway.AddYears(-1))
                        orderby p
                        select p;
