    var duplicates = listTextBox
            .GroupBy(i => i.Text)
            .Where(g => g.Count() > 1)
            .Select(g => new {Count = g.Count(), 
                              Name = g.Key});
        foreach (var d in duplicates)
        {
            var keyName = d.Key;
            var count = d.Count;
        }
