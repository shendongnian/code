    var subquery = QueryOver.Of<AddressCompany>()
        .Where(c => c.CreationDate > new DateTime(2000, 1, 1))
        .Select(c => c.Company.ID);
    var query = session.QueryOver<Company>()
        .WithSubquery
        .WhereProperty(c => c.ID)
        .In(subquery)
        ...;
