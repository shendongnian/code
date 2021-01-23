    List<List<List<double>>> list = new List<List<List<double>>>()
    {
        new List<List<double>>()
        {
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){6,2,3 },
            new List<double>(){5,2,5 },
        },
        new List<List<double>>()
        {
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){6,2,3 },
            new List<double>(){5,2,5 },
        },
        new List<List<double>>()
        {
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){5,2,3 },
            new List<double>(){5,2,5 },
        },
        new List<List<double>>()
        {
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){1,2,3 },
            new List<double>(){5,2,5 },
            new List<double>(){5,2,3 },
            new List<double>(){5,2,5 },
        }
    };
    
    var result = list.FindAll(x=>x[4].Contains(6));
    int[] indices = list.Select((item, index) => new { x = item, i = index })
                        .Where(x => x.x[4].Contains(6))
                        .Select(x => x.i).ToArray();
