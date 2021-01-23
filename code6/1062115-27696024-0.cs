     if(contact.Categories.ToString() == "Dont Sync")
     {
         //Don't Sync Contact
         If(googleContact.Exists())
         {
             //Delete contact from Google if it exist
             googleContact.Delete();
         } 
     }
     else
     {
         //Sync Contact
     }
