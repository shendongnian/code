    private class Account
    {
        public const String SObjectTypeName = "Account";
        public String Id { get; set; }
        public String Name { get; set; }
        public ContactsResult Contacts { get; set; }
    }
    private class ContactsResult
    {
        public Contacts[] Records { get; set; }
    }
    private class Contacts
    {        
        public String Id { get; set; }
        public String Name { get; set; }
    }
