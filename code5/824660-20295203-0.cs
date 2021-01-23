    var result =
    File.ReadAllLines("TextFile.txt")
        .Select((line, i) => new { Line = line, LineNumber = i })
        .GroupBy(a => a.LineNumber / 5,
                 a => a.Line,
                (key, values) => new 
                {
                    Number = key,
                    Class = new cEspecie()
                    {
                        LifeTime = int.Parse(values.ElementAt(0)),
                        Movility = int.Parse(values.ElementAt(1)),
                        DeadTo = int.Parse(values.ElementAt(2)),
                        Type = int.Parse(values.ElementAt(3)),
                        Name = values.ElementAt(4)
                    }
                })
        .GroupBy(a => a.Number / Length2,
                 a => a.Class,
                 (key, values) => values.ToList())
        .ToList();
