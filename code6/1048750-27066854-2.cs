    void Run()
    {
        Initial();
        var selectedContracts = SelectContacts(contactList, 
          new[] { "Group A", "Group B" });
        PrintContacts(selectedContracts);
    }
