    public partial class UserModel
    {
    public UserModel()
    {
    }
    public long UserId { get; set; }
    public long SiteId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public byte FailedAttempts { get; set; }
    public System.DateTime LastLogin { get; set; }
    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public System.DateTime CreatedOn { get; set; }
    public System.DateTime LastChanged { get; set; }
    public virtual User User { get; set; }
    }
