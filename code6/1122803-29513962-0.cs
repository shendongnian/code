    // change AddressLines definition to such:
    public class AddressLines 
    {
         // your other properties
         // ..
         public string Address1 {get;set;}
         public string Address2 {get;set;}
         public string Address3 {get;set;}
         public string Address4 {get;set;}
         public string Address5 {get;set;}
         public string PostCode{get;set;}
          
         public IEnumerable<String> AddressLines
         {
             get 
             {
                 return new [] {
                        this.Address1,
                        this.Address2,
                        this.Address3,
                        this.Address4,
                        this.Address5,
                        this.Postcode
                  };
             }
         }
    } 
