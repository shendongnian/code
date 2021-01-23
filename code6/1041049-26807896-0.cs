    db.Table1.Join(db.Table2.ToList(),
                   t1 => t1.ID,
                   t2 => t2.T1_ID,
                   (t1, t2) => new { Table1, Table2})
             .Where(result => result.Table1.LogDate >= result.Table2.StartDate &&
                              result.Table1.LogDate <= result.Table2.EndDate);
