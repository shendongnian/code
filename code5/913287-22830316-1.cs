            // left join: left table = TableA, right table = TableB
            var q1 = (from a in TableA
                      join b in TableB on a.ID equals b.ID into JoinedList
                      from b in JoinedList.DefaultIfEmpty()
                      select new
                      {
                          a,
                          b
                      });
            // right join: left table = TableB, right table = TableA
            var q2 = (from b in TableB
                      join a in TableA on b.ID equals a.ID into JoinedList
                      from a in JoinedList.DefaultIfEmpty()
                      select new
                      {
                          a,
                          b
                      });
            var query = q1.Union(q2).ToList();
