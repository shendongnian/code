    result = context
        .Items
        .Where(b => !b.Deleted)
        .OrderBy(b => b.Name)
        .AsEnumerable()
        .Select((v,i) => new { i, v.Name })
        .ToDictionary(g => g.i + 1, g => g.Name);
