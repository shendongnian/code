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
                ctx.Set<Parent>().Select(i => new
                    {
                        i.Id,
                        e = ctx.Set<Child>().Where(c => c.ParentId == i.Id).OrderBy(c => c.Name).FirstOrDefault(),
                        l = ctx.Set<Child>().Where(c => c.ParentId == i.Id).OrderByDescending(c => c.Name).FirstOrDefault()
                    });
