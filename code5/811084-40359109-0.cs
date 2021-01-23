        public class FinancialData
    {
        public string Accounts { get; set; } // this will store the JSON string
        public List<Accounts> AccountsList { get; set; } // this will be the actually list. 
    }
        public class Accounts
    {
        public string bank { get; set; }
        public string account { get; set; }
        public string agency { get; set; }
        public string digit { get; set; }
    }
