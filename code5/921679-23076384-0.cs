    var result = (from row in DTgraph.AsEnumerable()
             group row by row.Field<string>("Campaign") into grp
             select new
             {
                 Campaign = grp.Key,
                 Count = grp.Count(),
                 SL = grp.Sum(s => s.Field<Decimal>("Inb.ServiceLevel"))
             }).ToList();
    if(result.Count() > 0)
    {
      ///Do Something//// 
    }
