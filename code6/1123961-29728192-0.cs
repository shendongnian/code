            //declare intervals
        var secondryIntervals = new List<Tuple<DateTime, DateTime>> {
                new Tuple<DateTime, DateTime>( new DateTime(2015, 03, 15, 4, 0, 0), new DateTime(2015, 03, 15, 5, 0, 0)),
                new Tuple<DateTime, DateTime>( new DateTime(2015, 03, 15, 4, 10, 0), new DateTime(2015, 03, 15, 4, 40, 0)),
                new Tuple<DateTime, DateTime>( new DateTime(2015, 03, 15, 4, 40, 0), new DateTime(2015, 03, 15, 5, 20, 0))};
        var mainInterval = new Tuple<DateTime, DateTime>(new DateTime(2015, 03, 15, 3, 0, 0), new DateTime(2015, 03, 15, 7, 0, 0));
        // add two empty intervals before and after main interval
        secondryIntervals.Add(new Tuple<DateTime, DateTime>(mainInterval.Item1.AddMinutes(-1), mainInterval.Item1.AddMinutes(-1)));
        secondryIntervals.Add(new Tuple<DateTime, DateTime>(mainInterval.Item2.AddMinutes(1), mainInterval.Item2.AddMinutes(1)));
        secondryIntervals = secondryIntervals.OrderBy(s => s.Item1).ToList();
        // endDate will rember 'biggest' end date
        var endDate = secondryIntervals.First().Item1;
        var result = secondryIntervals.Select(s =>
        {
            var temp = endDate;
            endDate = endDate < s.Item2 ? s.Item2 : endDate;
            if (s.Item1 > temp)
            {
                return new Tuple<DateTime, DateTime>(temp < mainInterval.Item1 ? mainInterval.Item1 : temp,
                                                     mainInterval.Item2 < s.Item1 ? mainInterval.Item2 : s.Item1);
            }
            return null;
        })
            // remove empty records
                        .Where(s => s != null && s.Item2 > s.Item1).ToList();
        var minutes = result.Sum(s => (s.Item2 - s.Item1).TotalMinutes);
