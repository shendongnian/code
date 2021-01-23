    public class IdentityUserLogin
    {
    
     public IdentityUserLogin();
    public virtual string LoginProvider { get; set; }
    public virtual string ProviderKey { get; set; }
    public virtual string UserId { get; set; }  // if i am the key to IdentityUser
     [ForeignKey("UserId")] //  IdentityUserId instead of USerId may have worked.
                            //  see http://msdn.microsoft.com/en-us/data/jj713564 and  
                            // http://msdn.microsoft.com/en-us/data/jj591583
    public virtual IdentityUser User { get; set; }
}
