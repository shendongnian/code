    // Get contacts that have a mobile number
    IQueryable<Contact> contactsWithANumber = context.Contacts.Select(x => !string.IsNullOrWhiteSpace(x.MobileNumber));
    // Update IsSent to 1
    foreach(Contact c in contactsWithANumber)
    {
        c.IsSent = 1;
    }
    // Update in db.
    context.SaveChanges();
   
    
    
