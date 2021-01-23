    public string[] GetCodes(string prefixText)
    {
      return MyDB.tblCountries.Where(country=>country.CountryCode.
             StartsWith(prefixText)).OrderBy(country=>country.CountryCode).Select(country => country.CountryCode + "(" + country.CountryName + ")").ToArray();    
    }
