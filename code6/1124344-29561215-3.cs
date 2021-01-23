    //no need for Dynamic Linq here
    public static List<Contact> Search<T>(Expression<Func<Contact, T>> filtre)
    {
        var contacts = Contacts.OrderBy(filtre).ToList();
        return contacts;
    }
    ...
    Contacts = Search(c => c.SomeProperty);
