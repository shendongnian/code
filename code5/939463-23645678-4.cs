    //solution starts from here
    var data = table1.AsEnumerable().GroupBy(m => m.Field<string>("GroupName")).Select(grp => new
    {
        GroupName = grp.Key,
        Count = (int)grp.Count()
    }).ToList();
