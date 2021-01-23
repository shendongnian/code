    foreach (var g in list.GroupBy(p => new { p.Name, p.AssignedArea }))
    {
        var p = g.First();
        if (g.Count() > 1)
        {
            p.Program = "All Programs";
        }
        yield return p;
    }
