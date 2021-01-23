    public class User : BaseEntity<Guid>
        {
           public string UserName { get; set; }
           public string Email { get; set; }
           public string Password { get; set; }      
           public virtual UserProfile userProfile { get; set;}
        }
    }
    3. Create User Profile Entity
    
    using System;
    namespace Ioc.Core.Data
    {
      public class UserProfile : BaseEntity<int>
        {
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public string Address { get; set; }
          public Guid UserId { get; set; }
          public virtual User User { get; set; }
        }
    }
