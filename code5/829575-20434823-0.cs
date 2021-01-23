    public class MyData
    {
        public string CountryRegion {get;set;}
        public string Country {get; set;}
    
        public string Location
        get()
        { 
          return CountryRegion+" " + Country;
        }
    }
