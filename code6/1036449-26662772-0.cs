            var userResults =
                (
                    from u in myDB.Users
                    join tc in myDB.TriviaCodes on u.userID equals tc.userID
                    where
                        (tc.dateRedeemed.Value.Hour < 20
                            ? tc.dateRedeemed.Value.Date == date.Date
                            : tc.dateRedeemed.Value.Date == yesterday.Date)
                    select new
                    {
                        u,
                        tc
                    }
                )
     
           .GroupBy(k => k.u.userID)
                    .Select(group => new
                    {
                        user = group.First().u,
                        points = group.Sum(p => p.tc.pointsGained)
                    })
           .OrderByDescending(u => u.points)
           .Where(u => u.points > 0)
           .Select(u => u)
           .Take(100)
           .ToList();
