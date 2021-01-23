    public class User
    {
      // other properties.
        
      public virtual Country Country;
    }
      
    public class Country 
    { 
       public int Id {get;set;}
       public string CountryCode {get;set;}
    }
