    var countryViewModel = context.Country.Select(c => new CountryEditModel
        {
            Code = c.Code,
            Name = c.Name,
            id = c.id
        }).ToList();
