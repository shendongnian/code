    namespace Microsoft.AspNet.Identity.EntityFramework
    {
      /// <summary>
      /// Default EntityFramework IUser implementation
      /// 
      /// </summary>
      public class IdentityUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser, IUser<string>
      {
        public IdentityUser()
        {
          this.Id = Guid.NewGuid().ToString();
        }
    
        public IdentityUser(string userName)
          : this()
        {
          this.UserName = userName;
        }
      }
    }
