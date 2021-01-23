    var items = new [] {
        new { F1 = "ID1", F2 = "ID2", S = "AA", V = 15 },
        new { F1 = "ID3", F2 = "ID2", S = "AA", V = 20 },
        new { F1 = "ID1", F2 = "ID4", S = "AA", V = 25 },
        new { F1 = "ID1", F2 = "ID4", S = "AA", V = 5  },
        new { F1 = "ID1", F2 = "ID4", S = "AB", V = 5  },
    };
    
    var f2s = items.Select(i => i.F2).Distinct();
    
    var table =
        from i in items
        group i by new { i.F1, i.S } into g
        select new 
        { 
            g.Key, 
            V = 
                from f in f2s
                join x in g on f equals x.F2  into ps 
                from p in ps.DefaultIfEmpty()
                select new { F = f, V = p != null ? p.V : 0 } into w
                group w by w.F into h
                select new { h.Key, V = h.Sum(c => c.V) }
        };
