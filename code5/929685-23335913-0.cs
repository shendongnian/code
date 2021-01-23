    public IEnumerable<Contact> GetContacts(IContactManager contactManager, string query)
    {
        IEnumerable<Contact> contacts = contactManager.GetContacts(query)
            .DefaultIfEmpty(new Contact { Name = "Example" });
        return contacts;
    }
