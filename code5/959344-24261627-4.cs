     var data = DataBase.Table1.AsEnumerable().Select((t1,i) => new { t1, i })
                .Join(DataBase.Table2.AsEnumerable().Select((t2,i) => new { t2, i }),
                      x1 => x1.t1.Id,
                      x2 => x2.t2.Id,
                      (x1, x2) => new { 
                          Value = x1.t1.Id, 
                          Text = x2.t2.Description,
                          Index1 = x1.i,
                          Index2 = x2.i
                      })
                .OrderBy(x => x.Value)
                .ToList();
