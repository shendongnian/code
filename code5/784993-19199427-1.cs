    var lst = new List<List<string>>()
    {
        new List<string>(){"A","22"},
        new List<string>(){"B","7"},
        new List<string>(){"C","4"},
        new List<string>(){"D","3"},
        new List<string>(){"E","10"},
        new List<string>(){"F","5"},
        new List<string>(){"G","1"},
    };
    var result = lst.OrderByDescending(p=>Int32.Parse( p[1] )).Take(5);
