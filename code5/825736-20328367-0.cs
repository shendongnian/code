    var result =
        (from times in data.Times
            join users in data.Users on times.UserId equals users.UserID
            select new
            {
                UserName = users.FirstName + " " + users.LastName, 
                ExpectedHours = users.ExpectedWeeklyHours, 
                WorkHours = times.TimeSpent
            } into x
            group x by new
            {
                UserName = x.UserName,
                ExpectedWorkingHours = x.ExpectedHours
            }
            into g
        ).AsEnumerable().Select(new {
                UserName = g.Key.UserName,
                ExpectedWorkingHours = g.Key.ExpectedWorkingHours,
                TotalWorkingHours = new TimeSpan(g.Sum(w => w.WorkHours.Ticks))
          }.ToList();
