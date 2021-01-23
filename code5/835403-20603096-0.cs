    var countryCodes = hbcampaign.HBTargetingSpec.HBCountries.Select(c => country.country_code);
    // Gives you the list of existing countries in one SQL query
    var existingCountries = db.HBCountries.Where(c => 
    	countryCodes.Contains(c.country_code);  
    
    foreach (HBCountry country in existingCountries)
    {
    	var existingCountry = hbcampaign.HBTargetingSpec.HBCountries.FirstOrDefault(c => c.country_code == country.country_code);
    	existingCountry.CountryID = country.CountryID;
    	db.HBCountries.Detach(country);
    	db.HBCountries.Attach(existingCountry);
    }
    
    var newCountries = hbcampaign.HBTargetingSpec.HBCountries.Where(c => !existingCountries.Any(c2 => c2.country_code == c.country_code);
    foreach (HBCountry country in newCountries)
    	db.HBCountries.Add(country);
