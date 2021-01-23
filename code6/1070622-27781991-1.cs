    List<string> list = new List<string> { "StringA", "StringB", "StringC", "StringA", "StringA", "StringB" };
    var newList =
        list.Select((r, i) => new { Value = r, Index = i })
        .GroupBy(r => r.Value)
        .Select(grp => grp.Count() > 1 ?
                    grp.Select((subItem, i) => new
                    {
                        Value = subItem.Value + (i + 1),
                        OriginalIndex = subItem.Index
                    })
                    : grp.Select(subItem => new
                    {
                        Value = subItem.Value,
                        OriginalIndex = subItem.Index
                    }))
        .SelectMany(r => r)
        .OrderBy(r => r.OriginalIndex)
        .Select(r => r.Value)
        .ToList();
