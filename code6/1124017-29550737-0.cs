    var resultList = List1.OrderByDescending(o => o.Cnt).Take(10).Select(s =>
    {
        List2.Add(s);
        return s;
    }).ToList();  //Now List2 has 10 items.
