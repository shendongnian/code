    class Cities
    {
     public string City{get;set;}
     public int CityId{get;set;}
     public int CountryId{get;set;}
    
     public static List<Cities>MyCities()
     {
      var c1 = new Cities{ CityId = 1, City= "Antwerp", CountryId = 1};
      var c2 = new Cities{ CityId = 2, City= "Den Haag", CountryId = 2};
      var c3 = new Cities{ CityId = 3, City= "Brussels", CountryId = 1};
      var c4 = new Cities{ CityId = 4, City= "Rotterdam", CountryId = 2};
      var c5 = new Cities{ CityId = 5, City= "Amsterdam", CountryId = 2};
      var c6 = new Cities{ CityId = 6, City= "Hasselt", CountryId = 1};
    
      var result= new List<Cities>();
      result.Add(c1);
      result.Add(c2);
      result.Add(c3);
      result.Add(c4);
      result.Add(c5);
      result.Add(c6);
     
      return result;
     }
    
     public static List<Cities>SelectedCities(int countryId)
     {
      //Linq Example
      var l = MyCities();
      var result = from m in l 
                   where m.CountryId = countryId
                   select m;
      return result;
      //you also could use a foreach or For loop
      //var l = MyCities();
      //var result = new List<Cities>();
      //foreach(var item in l)
      //{
      // if(item.CountryId == countryId)
      // { 
      //  result.Add(item);
      // }
      // return result;
      }
     }
    }
