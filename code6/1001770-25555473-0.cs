    var dt1 = new List<MyClass>();
    dt1.Add(new MyClass { FirstName = "Tony", LastName = "Stark", Val1 = 34, Val2 = 35});
    dt1.Add(new MyClass { FirstName = "Steve", LastName = "Rogers", Val1 = 12, Val2 = 23});
    dt1.Add(new MyClass { FirstName = "Natasha", LastName = "Romanoff", Val1 = 2, Val2 = 100 });
    var dt2 = new List<MyClass>();
    dt2.Add(new MyClass { FirstName = "Tony", LastName = "Stark", Val1 = 16, Val2 = 5 });
    dt2.Add(new MyClass { FirstName = "Bruce", LastName = "Banner", Val1 = 2, Val2 = 1 });
    dt2.Add(new MyClass { FirstName = "Steve", LastName = "Rogers", Val1 = 54, Val2 = 40 });
    
    var q = from a in dt1
                    .Concat(
                        from b in dt2 
                        select new MyClass 
                            {
                                FirstName = b.FirstName,
                                LastName = b.LastName,
                                Val1 = b.Val1 * 0.5m,
                                Val2 = b.Val2 * 0.5m
                            })
            group a by new {a.FirstName, a.LastName}
            into g
            select new
                {
                    g.First().FirstName,
                    g.First().LastName,
                    Val1 = g.Sum(x => x.Val1),
                    Val2 = g.Sum(x => x.Val2),
                };
    foreach (var s in q)
    {
        Console.WriteLine("{0} {1} {2} {3}", s.FirstName,s.LastName,s.Val1,s.Val2);
    }
