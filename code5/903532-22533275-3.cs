    public Task<Country> GetAllCountries()
      {
        return Task.Factory.StartNew(() => 
        {
            PoorCountryDAO.GetAllcountries()); 
     
            // some data transformation ...
        
            return result;
        });
      }
