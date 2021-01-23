    var result = from x in (from p in _ctx.Table1
                           .Where(x => x.Deleted == 1 && x.Ready == 1 && x.Show == 0)
                 join s in _ctx.Table2
                 on p.Id equals s.Id into g
                 from result1 in g.DefaultIfEmpty()
                 select new
                 {
                     ID = result1 == null ? 0 : result1.Id   
                 })
                 join y in _ctx.Table3
                 on x.ID equals y.ID into g2
                 from result2 in g2.DefaultIfEmpty()
                 select new 
                 {
                     ContactNo = x.Table2.ContactNo ,
    	             //Fetch other columns
                 };
