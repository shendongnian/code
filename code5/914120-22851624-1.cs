    public IEnumerable<Contacts> GetAllContacts
    {
        get 
        {
            var Contacts = from c in dbc.Contact select c;
            return (IEnumerable<Contact>)Contacts;
        }
    }
