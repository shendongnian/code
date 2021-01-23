    // Get contacts that have a mobile number
    IQueryable<Contact> contactsWithANumber = context.Contacts.Select(x => !string.IsNullOrWhiteSpace(x.MobileNumber));
    // foreach
    foreach(Contact c in contactsWithANumber)
    {
        c.IsSent = 1;
    }
    // .ForEach()
    contactsWithANumber.ForEach(c => c.IsSent = 1);
    // Update in db.
    context.SaveChanges();
   
    
    
