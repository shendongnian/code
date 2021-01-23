    // Target method
    public IEnumerable<ContactModel> SelectContact()
    {
        return from contact in contactList
               where contact.ContactGroups.Contains("Group A") || 
                     contact.ContactGroups.Contains("Group B")
               select contact;
    }
    // Data
    public class ContactModel
    {
        public string CustomKey { get; set; }
        public string[] ContactGroups { get; set; }
    }
    private List<ContactModel> contactList;
    // Examples of usage
    public void Run()
    {
        Initial();
        var selectedContracts = SelectContact();
        PrintContacts(selectedContracts);
    }
    private void Initial()
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
