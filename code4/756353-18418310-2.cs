    Context.Table1.Select(t1 => new {
                                        A = t1.PropA,
                                        B = t1.PropB,
                                        Date = t1.Date
                                    })
    .Union(
    Context.Table1.Select(t2 => new {
                                        A = t2.PropC,
                                        B = t2.PropD,
                                        Date = t2.Date
                                    }))
    .OrderBy(x => x.Date)
    .ToList();
