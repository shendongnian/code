    var contactFromDb = db.Contacts.Include("Emails").Include("Telephones").FirstOrDefault(x => x.Id == updatedContact.Id);
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
