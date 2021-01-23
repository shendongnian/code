    var query = db.ZEM_LIC_UCH
                   .OrderBy(o => o.SERRIA_NUMBER)
                   .GroupBy(g => g.SERRIA_NUMBER)
                   .Select(s => new { s, Count = s.Count() })
                   .SelectMany(sm => sm.s.Select(s => s)
                      .Zip(Enumerable.Range(1, sm.Count), (row, index) => 
                      new { 
                         rn = index, 
                         row.SERRIA_NUMBER, 
                         row.DATE_REG_END, 
                         row.DATE_CHANGE 
                      }))
                   .ToList();
