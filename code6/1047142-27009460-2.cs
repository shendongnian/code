    var parentNodes = data
        .Where(i => i.AncestorId == i.DescendantId &&
                    (data.Count(d => d.DescendantId == i.DescendantId) == 1))
        .ToList();
    var root = new ProfitCenterRoot();
    foreach (var parentNode in parentNodes)
    {
        AddChildren(parentNode, data.Except(parentNodes).ToList());
        root.Data.Add(parentNode);
    }
