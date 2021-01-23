    var dating = from d in dates
                 let PreviousDate = d.PreviousOfWeek(DayOfWeek.Monday)
                 let NextWeekDate = d.NextDayOfWeek(DayOfWeek.Sunday)
                 group d by new 
                           { 
                             d.Day, 
                             d.DayOfWeek, 
                             d.Date, 
                             NextWeekDate 
                           } into g
                 where g.Key.DayOfWeek == DayOfWeek.Monday
                 select new 
                       { 
                         StartWeekDate = g.Key.DayOfWeek != DayOfWeek.Monday ? g.Key.Date.PreviousOfWeek(DayOfWeek.Monday) : g.Key.Date, 
                          EndWeekDate = g.Key.NextWeekDate 
                       };
