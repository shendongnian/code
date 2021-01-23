    public class AcctHolder
    {
        private string fname;
        public string FName 
        {
            get { return fname; }
            set { fname = value; }
        }
        private string lname;
        public string LName 
        {
            get { return lname; }
            set { lname = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        } 
        public AcctHolder(string a, string b, string c)
        {
            fname = a;
            lname = b;
            city = c;
        }
        public AcctHolder()
        {
        }
    }
