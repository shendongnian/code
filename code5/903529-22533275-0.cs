    public Task<Country> GetAllCountries()
      {
        var countries = PoorCountryDAO.GetAllcountries(); // poor static API call
    
        // some data transformation ...
    
        return Task.FromResult(result);
      }
