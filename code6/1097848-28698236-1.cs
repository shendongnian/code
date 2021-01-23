    foreach(var ec in db.Engineers.Where(x => x.CompanyId == companyId))
    {
        db.Engineers.Remove(ec);
    }
    // same logic here for other tables
