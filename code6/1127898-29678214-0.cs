    var myGroups = finds
       .GroupBy(a => a.Name)
       .Select(g => new {
            ProductName = g.Key,
            Context = g.Select(v => v.Context).ToList(),
            // This one is tricky: only one possible answer?
            PublicFacing = g.Select(v => v.PublicFacing).FirstOrDefault(),
            Installs = g.Sum(v => v.Installs))
        });
