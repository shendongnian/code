    var myEnum = List1.OrderByDescending(o => o.Cnt).Take(10).Select(s =>
    {
        List2.Add(s);
        return s;
    });
    foreach (var e in myEnum)
        ; // do nothing, just iterate.
