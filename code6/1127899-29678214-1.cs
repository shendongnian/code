    var myGroups = finds
       .GroupBy(a => a.Name)
       .Select(g => new SoftwareLight() {
            ProductName = g.Key,
            // "OR" through aggregation.
            Context = g.Aggregate((Context)0, (c, v) => c | v.Context),
            // True if any is public facing
            PublicFacing = g.Any(v => v.PublicFacing),
            Installs = g.Sum(v => v.Installs))
        });
