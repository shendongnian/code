    public static List<StateProvince> GetStateProvinceListAsync(string countryId)
    {
       // Check to see if I already have this data cached
       if(gotData)
       {
          // Life is good! Get data from cache.
       }
       else
       {
          // Don't have the data cached. Call the DB read method
          statesList = ReadStateProvinceList(countryId)
       }
    }
    private static List<StateProvince> ReadStateProvinceList(string countryId)
    {
       // Call Azure SQL Database to read data. No async code here!
    }
