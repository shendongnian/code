    void Run()
    {
        Initial();
        var selectedContacts = SelectContacts(contactList, 
          new[] { "Group A", "Group B" });
        PrintContacts(selectedContacts);
    }
