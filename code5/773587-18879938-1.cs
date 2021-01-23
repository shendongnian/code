    IList<MyClass> items = dt.AsEnumerable().GroupBy(
        row =>
            new
            {
                A = row.Field<int>("A"),
                B = row.Field<int>("B"),
                C = row.Field<int>("C"),
            },
        (key, values) =>
            new MyClass
            {
                A = key.A,
                B = key.B,
                C = key.C,
                Children = values.Select(row =>
                    new ChildClass
                    {
                        D = row.Field<string>("D"),
                        E = row.Field<string>("E"),
                    }).ToList()
            }).ToList();
