        using (ContactLINQDataContext context = new ContactLINQDataContext("Data Source=WORK-PC;Initial Catalog=Steve Harvey Team;Integrated Security=True"))
        {
            Contact contact = context.Contacts.SingleOrDefault(x => x.ContactID == contactID);
            Contact spouse = context.Contacts.SingleOrDefault(x => x.ContactID == contact.Spouse);
            Property property = context.Properties.SingleOrDefault(x => x.PropertyID == contact.Address);
    }
