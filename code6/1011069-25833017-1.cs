    foreach (var email in updatedContact.Emails)
    {
        // If id of an email is not equal to 0, it's not new email and it should be updated
        if (email.Id > 0)
        {
            var emailInDb = contactFromDb.Emails.Single(e => e.Id == email.Id);
            db.Entry(emailInDb).CurrentValues.SetValues(email);
            db.Entry(emailInDb).State = EntityState.Modified;
        }
    }
