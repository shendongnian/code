    public class BankAccount
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public ICollection<Deposit> Deposits { get; set; }
    }
    public class Deposit
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
