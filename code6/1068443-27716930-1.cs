    // before adding the model to the dbcontext
    model.UserName=Encrypt(mode.UserName);
    db.Users.Add(model);
    db.SaveChanges();
    [Table("Users")]
    public class User
    {
        #region database table column mapped fields
        [Key]
        [Required]
        public Int32 UserID { set; get; }
    
        [Required]
        [MaxLength(50)]
        public String UserName { set; get; } // this field will be encrypted field
    
        [Required]
        public Int32 CustID { set; get; }
    
        [NotMapped]
        public string DecryptedUserName
        {
            get { return Decrypt(UserName); }  // this you can display it to the user
        }
    }
