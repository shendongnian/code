    var lookup = dataRow.Skip(1)
        .Select((data, index) => new { lookup = index % 2, index = index, data = data})
        .ToLookup(d => d.lookup);
    var rights = lookup[0].Join(lookup[1],
            system => system.index + 1,
            username => username.index,
            (system, username) => new
            {
                system = system.data,
                useraname = username.data
            })
            .Where(d => !string.IsNullOrEmpty(d.system))
            .ToDictionary(d => d.system, d => d.useraname);
