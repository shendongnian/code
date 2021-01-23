     // let's say we have a static method called
     GetContacts() // that returns System.Data.DataTable  
     var individuals = GetContacts(ContactTypes.Individuals); 
    
     // how is it clear to the reader that I can do this?   
     return individuals.Compute("MAX(Age)", String.Empty);
   
