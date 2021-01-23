    dt.AsEnumerable().GroupBy(row =>
        new
            {
                A = row.Field<int>("A"),
                B = row.Field<int>("B"),
                C = row.Field<int>("C"),
            })
        .Select(x =>
            new MyClass
            {
                A = x.Key.A,
                B = x.Key.B,
                C = x.Key.C,
                Children = x.Select(row =>
                    new ChildClass
                    {
                        D = row.Field<string>("D"),
                        E = row.Field<string>("E"),
                    }).ToList()
            }).ToList();
