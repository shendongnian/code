    var query3 = from q3 in query2
                 group q3
                    by new { q3.Dept, q3.NeedOnWeek, q3.Status } into g
                 select new
                 {
                     dept = g.Key.Dept,
                     needOnWeek = g.Key.NeedOnWeek,
                     status = g.Key.Status,
                     count = g.Count()
                 };
