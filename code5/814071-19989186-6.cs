        var issues = new Tuple<int, string>[]
            {
                new Tuple<int, string>(1, "aaa"),
                new Tuple<int, string>(2, "bbb")
            };
        var notes = new Tuple<int, DateTime, string>[]
            {
                new Tuple<int, DateTime, string>(1, DateTime.Parse("01/01/2001"), "earliest for 1"),
                new Tuple<int, DateTime, string>(1, DateTime.Parse("02/01/2001"), "middle for 1"),
                new Tuple<int, DateTime, string>(1, DateTime.Parse("03/01/2001"), "latest for 1"),
                new Tuple<int, DateTime, string>(2, DateTime.Parse("10/01/2001"), "earliest for 2"),
                new Tuple<int, DateTime, string>(2, DateTime.Parse("11/01/2001"), "middle for 2"),
                new Tuple<int, DateTime, string>(2, DateTime.Parse("12/01/2001"), "once more middle for 2"),
                new Tuple<int, DateTime, string>(2, DateTime.Parse("13/01/2001"), "latest for 2")
            };
        var result =
            from i in issues
            select new
                {
                    i,
                    e = notes.Where(n => n.Item1 == i.Item1).OrderBy(n => n.Item2).First(),
                    l = notes.Where(n => n.Item1 == i.Item1).OrderByDescending(n => n.Item2).First(),
                };
    var result1 =
        from i1 in
            issues.Select(i => new
                {
                    i.Item1,
                    e = notes.Where(n => n.Item1 == i.Item1).OrderBy(n => n.Item2).First(),
                    l = notes.Where(n => n.Item1 == i.Item1).OrderByDescending(n => n.Item2).First(),
                })
        join i in issues on i1.Item1 equals i.Item1
        select i1;
