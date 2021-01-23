    [Table("Users")]
    public class User
    {
        #region database table column mapped fields
        [Key]
        [Required]
        public Int32 UserID { set; get; }
    
        [Required]
        [MaxLength(50)]
        public String UserName { set; get; }
    
        [Required]
        public Int32 CustID { set; get; }
    
        [NotMapped]
        public string EncryptedUserName
        {
            get { return Encrypt(UserName); } // your Encrypt function should handle the cases when username is empty or null
        }
    }
