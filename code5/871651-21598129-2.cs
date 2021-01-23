            var from = DateTime.Today.AddDays(-10);
            var to = DateTime.Today;
            var daysOfWeek = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday
                                              , DayOfWeek.Wednesday, DayOfWeek.Friday
                                              , DayOfWeek.Thursday };
            
            var days = Enumerable.Range(0, 1 + to.Subtract(from).Days)
                                 .Select((n, i) => from.AddDays(i).DayOfWeek)
                                 .Where(n => daysOfWeek.Contains(n.DayOfWeek));
