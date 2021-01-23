    class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public string BorP { get; set; }
    }
    class Tran
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
    }
    
    class TableAccount
    {
        public List<Account> Rows {get; set;}
    }
    class TableTrans
    {
        public List<Tran> Rows {get; set;}
    }
