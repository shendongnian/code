    var list = new List<CustomClass>
    {
        new CustomClass {Group = "Car", Color = "White"},
        new CustomClass {Group = "Motocycle", Color = "Blue"},
        new CustomClass {Group = "Car", Color = "Black"},
    };
    var results = list.GroupBy(c => c.Group).Select(g => new CustomClass()
        {
            Group = g.Key,
            Color = String.Join(", ", g.Select(c=>c.Color))
        }).ToList();
