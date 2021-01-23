    var result = (from row in DTgraph.AsEnumerable()
                 group row by row.Field<string>("Campaign") into grp
                 select new
                 {
                     Campaign = grp.Key,
                     Count = grp.Count(),
                     SL = grp.Sum(s => s.Field<Decimal>("Inb.ServiceLevel"))
                 }).ToList();
    for (int i = 0; i < result.Count(); i++)
    {
        //Your code here
        //Now you can do result[i].Something
    }
