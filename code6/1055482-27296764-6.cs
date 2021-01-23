    static void Example()
    {
        var masterSize = 10000;
        var aSize = 1000;
        var bSize = 100000;
        var masterList = Enumerable.Range(1, masterSize).ToArray();
        var aList = Enumerable.Range(1, aSize).ToArray();
        var bList = Enumerable.Range(1, bSize).Concat(Enumerable.Range(1, bSize)).ToArray();
        var w = new Stopwatch();
        //Subselect
        w.Restart();
        var x = (from m in masterList
                 join a in aList on m equals a
                 select new { A=a, M=m, B = bList.Where(b => b == m).ToList() }).ToList();
        w.Stop();
        Console.WriteLine("Test for SUBSELECT master={0};a={1};b={2} took {3}ms and returned {4}", masterSize, aSize, bSize, w.ElapsedMilliseconds, x.Count);
        //Join
        w.Restart();
        var y = (from m in masterList
                 join a in aList on m equals a
                 join b in (from b in bList group b by b) on m equals b.Key into bLeft
                 from bl in bLeft.DefaultIfEmpty()
                 select new { A = a, M = m, B = bl.ToList() }).ToList();
        w.Stop();
        Debug.Assert(x.Select(i => new { A = i.A, BC = i.B.Sum() }).SequenceEqual(y.Select(i => new { A = i.A, BC = i.B.Sum() })));
        Console.WriteLine("Test for JOIN master={0};a={1};b={2} took {3}ms and returned {4}", masterSize, aSize, bSize, w.ElapsedMilliseconds, y.Count);      
    }
