    class CustomContact
        {
            public string Name { get; set; }
        
           // public List<string> Numbers { get; set; }
            public string Number { get; set; }
        
        
            public CustomContact()
            {
            }
        
            public CustomContact(string displayName, string phoneNumber)
            {
                this.Name = displayName;
                this.Number = phoneNumber;
            }
        }
