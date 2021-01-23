    var groups = from g in context.Groups
                 where g.Station.Id == stationId
                 select new {
                    Id = g.Id,
                    ActiveUsers = g.Users.Where(u => u.Account.IsActive)
                 };
