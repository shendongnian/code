    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime OnWardDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual UserProfile User { get; set; }
    }
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual UserDetails Details { get; set; }
    }
    public class UserDetails
    {
        [Key]
        public int DetailsId { get; set; }
        public string DLNum { get; set; }
    }
