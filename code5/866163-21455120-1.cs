      var result =
                new DataTable().Rows.Cast<DataRow>()
                    .Select(p => new {User = p[0], Q = p[1], Value = (double) p[2]})
                    .GroupBy(p => new {p.User, p.Q})
                    .Select(p => new {User = p.Key.User, Q = p.Key.Q, Total = p.Sum(x => x.Value)})
                    .ToList();
