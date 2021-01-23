    // For insert
    if (cont == 1)
    {
       // Call your stored proc here
       // or if you add the company table to EF you can use the Insert use the Add 
       // e.g. Rough Example
       _yourEntities.Companies.Add(cmp);
       // Update the DB
       _yourEntities.SaveChanges();
    }
    else
    {
       var companies = _yourEntities.Companies.Where(c => c.isactive == 'True');
    }
