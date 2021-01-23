    void Initial()
    {
        contactList = new List<ContactModel>
        {
           new ContactModel
           {
               CustomKey = "1",
               ContactGroups = new[] { "Group A" }
           },
           new ContactModel
           {
               CustomKey = "2",
               ContactGroups = new[] { "Group A", "Group B", "Group C" }
           },
           new ContactModel
           {
               CustomKey = "3",
               ContactGroups = new[] { "Group C", "Group D" }
           },
           new ContactModel
           {
               CustomKey = "4",
               ContactGroups = new[] { "Group A", "Group B", "Group C", "Group D" }
           },
        };
    }
    static void PrintContacts(IEnumerable<ContactModel> contacts)
    {
        foreach (var selectedContract in contacts)
            Console.WriteLine(selectedContract.CustomKey);
    }
