    var values = samples.Descendants(XName.Get("param"))
        .Select(n => new {
            Name = n.Attribute(XName.Get("name")).Value,
            Value = float.Parse(n.Value)
        })
        .GroupBy(a => a.Name)
        .Select(a => new {
            Name = a.Key,
            MaxValue = a.Max(g => g.Value),
            MinValue = a.Min(g => g.Value),
            AvgValue = a.Average(g => g.Value)
        })
        .ToArray();
