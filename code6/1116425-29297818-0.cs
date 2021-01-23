    public class Transaction : BaseEntity
    {
        public string Message { get; set; }
        public double Amount { get; set; }
        public virtual long ToId { get; set; }
        [ForeignKey("ToId")]
        public virtual BankAccount To { get; set; }
        public virtual long FromId { get; set; }
        [ForeignKey("FromId")]
        public virtual BankAccount From { get; set; }
    }
