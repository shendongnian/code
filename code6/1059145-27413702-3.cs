    class Teacher 
    {
        public string FirstName
        {
            get;
            set;
        }
    
        public string LastName
        {
            get;
            set;
        }
    
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
    
        public Teacher(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
