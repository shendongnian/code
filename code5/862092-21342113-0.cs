    var query = data.AsQueryable()
        .Where(parts[0]).AsQueryable()
        .Where(parts[1]).AsQueryable()
        ...
        .Where(parts[N]).AsQueryable();
