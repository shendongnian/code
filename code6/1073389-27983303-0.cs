    string property = "Employees.PayrollNo";
    var query = session.QueryOver<Company>()
        .Fetch(x => x.Employees).Eager;
    // Join on the associations involved
    var parts = property.Split('.');
    var criteria = query.UnderlyingCriteria;
    for (int i = 0; i < parts.Length - 1; i++)
	{
        criteria.CreateAlias(parts[i], parts[i]);
    }
    // add the order
    criteria.AddOrder(new Order(property, !isDescending));
    var companies = query.List();
