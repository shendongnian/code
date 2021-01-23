    [Table("Accounts")]
    public class DbAccount
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
    
        [InverseProperty("Account")]
        public virtual DbLicense License { get; set; }
    }
    
    [Table("Licenses")]
    public class DbLicense
    {
        [Key, ForeignKey("Account")]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [InverseProperty("License")]
        public virtual DbAccount Account { get; set; }
    }
