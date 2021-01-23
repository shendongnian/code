    // Summary:
    //     Default EntityFramework IUser implementation
    //
    // Type parameters:
    //   TKey:
    //
    //   TLogin:
    //
    //   TRole:
    //
    //   TClaim:
    public class IdentityUser<TKey, TLogin, TRole, TClaim> : IUser<TKey>
        where TLogin : Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<TKey>
        where TRole : Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<TKey>
        where TClaim : Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>
    {
        // Summary:
        //     Constructor
        public IdentityUser();
        // Summary:
        //     Used to record failures for the purposes of lockout
        public virtual int AccessFailedCount { get; set; }
        //
        // Summary:
        //     Navigation property for user claims
        public virtual ICollection<TClaim> Claims { get; }
        //
        // Summary:
        //     Email
        public virtual string Email { get; set; }
        //
        // Summary:
        //     True if the email is confirmed, default is false
        public virtual bool EmailConfirmed { get; set; }
        //
        // Summary:
        //     User ID (Primary Key)
        public virtual TKey Id { get; set; }
        //
        // Summary:
        //     Is lockout enabled for this user
        public virtual bool LockoutEnabled { get; set; }
        //
        // Summary:
        //     DateTime in UTC when lockout ends, any time in the past is considered not
        //     locked out.
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        //
        // Summary:
        //     Navigation property for user logins
        public virtual ICollection<TLogin> Logins { get; }
        //
        // Summary:
        //     The salted/hashed form of the user password
        public virtual string PasswordHash { get; set; }
        //
        // Summary:
        //     PhoneNumber for the user
        public virtual string PhoneNumber { get; set; }
        //
        // Summary:
        //     True if the phone number is confirmed, default is false
        public virtual bool PhoneNumberConfirmed { get; set; }
        //
        // Summary:
        //     Navigation property for user roles
        public virtual ICollection<TRole> Roles { get; }
        //
        // Summary:
        //     A random value that should change whenever a users credentials have changed
        //     (password changed, login removed)
        public virtual string SecurityStamp { get; set; }
        //
        // Summary:
        //     Is two factor enabled for the user
        public virtual bool TwoFactorEnabled { get; set; }
        //
        // Summary:
        //     User name
        public virtual string UserName { get; set; }
    }
