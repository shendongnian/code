	var cities = _context.Cities.Select(x => new {
		ContryId = x.County.Country.CountryId,
		ContryName = x.County.Country.Name,
		CityId = x.Id,
		CityName = x.Name
	});
	var countryLookup = new Dictionary<int, CountryDto>(approximatelyCountOfCountries);
	foreach (var city in cities)
	{
		CountryDto country;
		if (!countryLookup.TryGetValue(city.CountryId, out country))
		{
			country = new CountryDto {
				Name = city.CountryName,
				Id = city.CountryId
				Cities = new List<CityDto>(approximatelyCountOfCities)
			};
			countryLookup.Add(country.Id, country);
		}
		country.Cities.Add(new CityDto { Name = city.Name, Id = city.Id });
	}
