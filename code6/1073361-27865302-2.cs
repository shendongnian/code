    List<dynamic> results = db.Query<dynamic, dynamic, dynamic, dynamic>(sql,
        (a, b, c) => { return new { a, b, c }; }).ToList(); // splitOn: 'Id'
    List<dynamic> a_ids = new List<dynamic>();
    List<dynamic> b_ids = new List<dynamic>();
    List<dynamic> c_ids = new List<dynamic>();
    
    List<A> unique_as = new List<A>();
    List<B> unique_bs = new List<B>();
    List<C> unique_cs = new List<C>();
    foreach (var row in results)
    {
        var a = row.a;
        var b = row.b;
        var c = row.c;
        if(!a_ids.Contains(a.Id)) unique_as.Add(new A(a.Id));
        if(!b_ids.Contains(b.Id)) unique_bs.Add(new B(b.Id));
        if(!c_ids.Contains(c.Id)) unique_cs.Add(new C(c.Id));
    }
