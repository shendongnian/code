        var people = new List<Tuple<int, string>> { new Tuple<int,string>(1000, "Tom"),
            new Tuple<int,string>(2200, "Mark"),
            new Tuple<int,string>(3000, "Antony"),
            new Tuple<int,string>(2500, "Paul"),
            new Tuple<int,string>(2800, "Kris"),
            new Tuple<int,string>(3110, "Ron"),
        };
        var ranges = new List<Tuple<int, int>> { new Tuple<int,int>(0,1500),
            new Tuple<int,int>(1501,2500),
            new Tuple<int,int>(2501,4000),
            
        };
        var result = ranges.GroupBy(p => people.Where(e => p.Item1 < e.Item1 && p.Item2 >= e.Item1), 
                                (key, g) => new { People = key.Select(k => k.Item2), Range = g })
                       .ToList();
