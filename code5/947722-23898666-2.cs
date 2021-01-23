    db.Contacts
        .Where(a => a.LastName.Contains(term))
        .Select(a => 
        new 
        { 
            a = a,
            primaryAddress = 
                a.Addresses
                    .FirstOrDefault(a => a.AddressType.Name.Contains("Primary"))
        })
        .Select(a =>
        new 
        {
            a.a.Id,
            value = a.a.LastName + ", " + a.a.FirstName + " " + a.a.MiddleName,
            a.a.Email,
            a.a.Title,
            Street1 = a.primaryAddress.Street1,
            Street2 = a.primaryAddress.Street2,
            City = a.primaryAddress.City,
            State = a.primaryAddress.State,
            Postal = a.primaryAddress.PostalCode,
            a.a.Institution.Name
        })
