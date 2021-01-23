    var query = from x in tbl1.Concat(tbl2.Select(t => new { ID = t.ID, Total = -t.Total }))
                group x by x.ID into x
                select new
                {
                  ID = x.Key,
                  Total = x.Sum(y => y.Total)
                };
