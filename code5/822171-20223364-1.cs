    namespace DataTeamMailerCSharp
    {
        [Serializable] 
        public class NewPerson
        {
            public string personName { get; set; }
            public string personEmail { get; set; }
            public string personReports { get; set; }
    
            public NewPerson(string name, string email, string reports)
            {
                personName = name;
                personEmail = email;
                personReports = reports;
            }
    
            public NewPerson() { } // for serialization
            // private extern NewPerson(); -- not needed
        }
    }
