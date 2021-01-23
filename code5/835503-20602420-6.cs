             ResponceDTO
               { 
                 public bool success {get; set;}
                 public string message {get; set;}
                 public dbPerson  person {get; set;}   
        //customer   can use the dbPerson, which can be the same or different
       // with the one  in the business-layer.  But this DTO is in the specs.                           
                }
                 RequestDTO
               { 
                 public id Id {get; set;}
                 public FilteByAge {get; set;}
                public FilteByZipCode {get; set;}
                }
