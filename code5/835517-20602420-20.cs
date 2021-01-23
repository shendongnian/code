               Person  { ... }
            
               Address  { ... }
               ResponceDTO
               { 
                 public bool success {get; set;}
                 public string message {get; set;}
                 public Person  person {get; set;}  
                 public List<Address> addresses {get; set;}  
        //customer can use the Person & Address, which can be the same or different
       //with the ones in the data-layer. But we have defined these POCO's  in the specs.                           
                }
               RequestDTO
               { 
                 public int Id {get; set;}
                 public FilteByAge {get; set;}
                public FilteByZipCode {get; set;}
                }               
               UpdatePersonRequest
               { 
                 public int Id {get; set;}
                 public bool IsNew {get; set;}
                 public Person  person {get; set;} 
                 public List<Address> addresses {get; set;}   
                }                  
                 
             
