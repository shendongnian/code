     from p in punches
     group p by new { p.EmployeeID, p.ShiftDate } into g
     let punch = g.First()
     select new Shift
     {
          EmployeeID = punch.EmployeeID,
          FirstName = punch.FirstName,
          LastName = punch.LastName,
          TimeClockID = punch.TimeClockID,
          Hours = g.OrderBy(p => p.TimeStamp)
                   .Select((p,i) => new {p,i})
                   .GroupBy(x => x.i / 2)
                   .Sum(inOut => inOut.Last().p.TimeStamp
                                         .Subtract(inout.p.First().TimeStamp)
                                         .TotalHours)
      }).ToList();
