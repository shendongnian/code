    // Class structure
    public class Account
    {
        public int AccountNumber;
        public string AccountName;
        public DateTime DateCreated;
    
        public Account(string[] info)
        {
            // This is all dependent that info passed in, is already valid data.  
            // Otherwise you need to validate it before assigning it
            AccountNumber = Convert.ToInt32(info[0]);
            AccountName = info[1];
            DateCrated = DateTime.Parse(info[2]);
        }
    }
