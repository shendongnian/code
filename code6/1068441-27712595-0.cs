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
      public string DecryptedUserName
      {
        get { return Decrypt(this.UserName); }
        set { this.UserName = Encrypt(value); }
      }
    }
