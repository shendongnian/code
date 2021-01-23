    Context.Table1.Select(t1 => new DateItem {
                                        A = t1.PropA,
                                        B = t1.PropB,
                                        Date = t1.Date
                                    })
    Union(
    Context.Table1.Select(t2 => new DateItem {
                                        A = t2.PropC,
                                        B = t2.PropD,
                                        Date = t2.Date
                                    }))
    .OrderBy(item => item.Date)
    .Cast<IDatedItem>()
    .ToList();
