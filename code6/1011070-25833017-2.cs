    var contactFromDb = db.Contacts.Include("Emails").Include("Telephones").FirstOrDefault(x => x.Id == updatedContact.Id);
    contactFromDb.Address = updatedContact.Address;
    contactFromDb.Name = updatedContact.Name;
    contactFromDb.Surname = updatedContact.Surname;
    
    // Delete removed emails
    var emailsToDelete = (from email in contactFromDb.Emails
                            let item = updatedContact.Emails.SingleOrDefault(i => i.Id == email.Id)
                            where item == null
                            select email).ToList();
    if (emailsToDelete.Any())
    {
        foreach (var email in emailsToDelete)
        {
            db.Entry(email).State = EntityState.Deleted;
        }
    }
