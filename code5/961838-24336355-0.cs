    var query = people.AsEnumerable();
    if (!String.IsNullOrEmpty(name))
        query = query.Where(p => p.Name == name);
    if (wantedProfessions.Any())
        query = query.Where(p => wantedProfessions.Contains(p.Profession));
