    var list = new List<Field>
    {
        new Field { Code = "A", Value = 10 },
        new Field { Code = "A", Value = 20 },
        new Field { Code = "B", Value = 30 },
    };
    
    var dic = list
        .GroupBy(z => z.Code)
        .ToDictionary(z => z.Key, z => z.Sum(f => f.Value));
