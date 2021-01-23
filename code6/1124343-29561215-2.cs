    using System.Linq.Dynamic;
    ...
    public static List<Contact> SearchDynamic(string filtre)
    {
        var contacts = Contacts.OrderBy(filtre).ToList();
        return contacts;
    }
    ...
    Contacts = SearchDynamic("SomeProperty");
