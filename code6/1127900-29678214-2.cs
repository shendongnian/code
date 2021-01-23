    var myGroups = finds
       .GroupBy(a => a.Name)
       .Select(g => new SoftwareLight() {
            Name = g.Key,
            // What should be done with the version field?
            // Right now, I am concatenating distinct versions.
            Version = string.Join(", ", g.Select(v => v.Version).Distinct()),
            // "OR" through aggregation.
            Context = g.Aggregate((AppContext)0, (c, v) => (AppContext)(c | v.Context)),
            // True if any is public facing
            External = g.Any(v => v.External),
            Installs = g.Sum(v => v.Installs))
        });
