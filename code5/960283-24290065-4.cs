    var predicate = PredicateBuilder.True<Country>();
    if (!string.IsNullOrWhiteSpace(searchAlpha2))
        predicate = predicate.And(c => c.Alpha2 != null ? c.Alpha2.Contains(searchAlpha2) : false);
    if (!string.IsNullOrWhiteSpace(searchAlpha3))
        predicate = predicate.And(c => c.Alpha3 != null ? c.Alpha3.Contains(searchAlpha3) : false);
    if (!string.IsNullOrWhiteSpace(searchName))
        predicate = predicate.And(c => c.Name != null ? c.Name.Contains(searchName) : false);
    IQueryable<Country> countries = db.Countries.AsExpandable().Where(predicate);
