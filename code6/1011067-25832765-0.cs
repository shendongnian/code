    var contactFromDb = db.Contacts.Include("Emails").Include("Telephones").Where(x => x.Id == contact.Id).FirstOrDefault();
    
    contactFromDb.Address = contact.Address;
    contactFromDb.Name = contact.Name;
    contactFromDb.Surname = contact.Surname;
    contactFromDb.Telephones = contact.Telephones;
    db.Entry(contactFromDb).State = System.Data.EntityState.Modified;
    foreach(Email email in contactFromDb.Emails)
    {
        db.Entry(email).State = System.Data.EntityState.Deleted;
    }
    contactFromDb.Emails.AddRange(contact.Emails);
    db.SaveChanges();
