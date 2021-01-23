    public class Account : EntityData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsBusiness { get; set; }
        
        public string User_Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User_Id")]
        [Association("UserIdAssociation", "UserId", "Id")]
        [Column(Order = 1)]
        public virtual User User { get; set; }
        public string Business_Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Business_Id")]
        [Association("BusinessIdAssociation", "BusinessId", "Id")]
        public virtual Business Business { get; set; }
    }
