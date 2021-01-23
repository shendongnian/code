        customers = db.Customers.Select(c => new
        {
            c.Id,
            c.FirstName,
            c.LastName,
            c.Address,
            c.Email,
            c.Phone,
            CountryName = c.Country.Name,
            c.Note
        };
