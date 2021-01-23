    public class BlockedUser
    {
    // User Foreign Key
    [ForeignKey("UserId")]
    public int UserId { get; set; }               // Composite Primary Key
    // User Foreign key
    [ForeignKey("BlockedUser_User")]
    public int ContactId { get; set; }            // Composite Primary Key
    // User Navigation Property
    public virtual User User { get; set; }
    }
    public class User
    {
    public int UserId { get; set; }  // Primary key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    // BlockedUser Navigation Property
    public virtual ICollection<BlockedUser> BlockedUsers { get; set; }
    }
