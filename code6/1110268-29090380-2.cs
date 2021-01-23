    class UserDetails
        {
            public string ID { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string FullRowDisplay { get; set; }
            public UserDetails(string id, string fName, string mName, string lName)
            {
                ID = id;
                FirstName = fName;
                MiddleName = mName;
                LastName = lName;
                FullRowDisplay = id + " " + fName + " " + mName + " " + lName;
            }
        }
