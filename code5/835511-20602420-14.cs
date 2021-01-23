            class   ResponceDTO
               { 
                 public bool success {get; set;}
                 public string message {get; set;}
                 public Person  person {get; set;}  
                 public List<Address> addresses {get; set;}  
        //customer   can use the Person & Address, which can be the same or different
       // with the ones  in the data-layer.  But these DTO is in the specs.                           
                }
                 RequestDTO
               { 
                 public id Id {get; set;}
                 public FilteByAge {get; set;}
                public FilteByZipCode {get; set;}
                }
              
                  
                  Person  { ... }
            
                   Address  { ... }
             
