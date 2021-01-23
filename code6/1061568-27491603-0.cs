    class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string BorP { get; set; }
        public List<Transaction> Transactions { get; set; }
    
    }
    
    class Tran
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
    }
