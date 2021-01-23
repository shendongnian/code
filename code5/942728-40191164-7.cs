     class CustomContact
    {
        public string Name { get; set; }
        public List<string> Numbers { get; set; }
        public CustomContact()
        {
        }
        public CustomContact(string displayName, List<string> phoneNumbers)
        {
            this.Name = displayName;
            this.Numbers = phoneNumbers;
        }
    }
