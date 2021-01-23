    public class IdentityUser : IUser<long>
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public long Id { get; set; }
    	public string UserName { get; set; }
    	public string PasswordHash { get; set; }
    	public virtual ICollection<ExternalLogin> Logins { get; set; }
    	public virtual ICollection<UserClaim> Claims { get; set; } 
    }
    
    public class ExternalLogin
    {
    	[Key]
    	public long Id { get; set; }
    	public string LoginProvider { get; set; }
    	public string ProviderKey { get; set; }
    	public string UserName { get; set; }
    	public virtual IdentityUser User { get; set; }
    }
    
    public class UserClaim
    {
    	[Key]
    	public long Id { get; set; }
    	public string Type { get; set; }
    	public string Value { get; set; }
    	public IdentityUser User { get; set; }
    }
