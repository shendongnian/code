    var nextRecord = 
        db.Reports.OrderBy(i => i.ID)
                  .AsEnumerable()
                  .SkipWhile(i => i.ID != id)
                  .Skip(1)
                  .First();                   
