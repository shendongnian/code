    var cities = _context.country.Distinct(c => c.Name).Where(c => c.Feature_Code != featureCode
                && c.Feature_Code != featureCode2
                && c.Country_Code == CountryCode
                && c.Admin1_code == StateId)
            .Select(c => new CityViewModel
            {
                CityId = c.CountryID,
                CityName = c.Name
            }
