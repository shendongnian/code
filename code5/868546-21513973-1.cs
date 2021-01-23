    var customer = Customer.Select(u => new
    {
        u.Name,
        u.Area,
        u.Telephone,
        u.Email,
        Blacklist = u.Blacklist.Any()
    })
    .ToList();
