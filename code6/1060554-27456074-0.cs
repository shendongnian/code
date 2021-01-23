    public class Transaction
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransType { get; set; }
    }
    public enum TransactionType
    {
        Income,
        Expense
    }
