    public class Import
        {
            public DateTime date { get; set; }
            public decimal amount { get; set; }
        }
    
        public class Export
        {
            public DateTime date { get; set; }
            public decimal amount { get; set; }
        }
    
        public class Result
        {
            public DateTime date { get; set; }
            public decimal creditAmount { get; set; }
            public decimal debitAmount { get; set; }
            public decimal balanceAmount { get; set; }
        }
