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
                   .Select((p,i) => new {Punch = p, Index = i})
                   .GroupBy(x => x.Index / 2)
                   .Select(inOut => new {
                       PunchInTime = inOut.First().Punch.TimeStamp, 
                       PunchOutTime = inOut.Last().Punch.TimeStamp 
                   })
                   .Sum(x => x.PunchOutTime.Subtract(x.PunchInTime).TotalHours)
      }).ToList();
