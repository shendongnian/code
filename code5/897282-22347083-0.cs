    public class User
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
    public class Transaction
    {
        public int TransactionId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
