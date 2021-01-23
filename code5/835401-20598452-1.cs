    var newList = new List<HBCountry>();
    foreach (HBCountry country in hbcampaign.HBTargetingSpec.HBCountries)
    {
         var countryMatch = db.HBCountries.FirstOrDefault(c => c.country_code == country.country_code)
    	 if (countryMatch != null)
         {
             newList.Add(countryMatch);
         }
         else
         {
             newList.Add(country);
         }                 
    }
    hbcampaign.HBTargetingSpec.HBCountries = newList;
