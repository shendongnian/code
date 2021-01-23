    class Countries
    {
     public string Country{get;set;}
     public int CountryId {get;set;}
    
     public static List<Countries>MyCountries()
     {
      var c1 = new Countries{ Country = "Belgium", CountryId = 1};
      var c2 = new Countries{ Country = "Netherlands", CountryId = 2};
      
      var result= new List<Countries>();
      result.Add(c1);
      result.Add(c2);
    
      return result;
     }
    }
    
