    public class IdentityUser<TKey, TLogin, TClaim, TGroup, TGroupRole> : IUser<TKey>
        where TLogin : IdentityUserLogin<TKey>
        where TClaim : IdentityUserClaim<TKey>
        where TGroup : IdentityGroup<TKey, TGroupRole>
        where TGroupRole : IdentityGroupRole<TKey>
    {
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual ICollection<TClaim> Claims { get; private set; }
        public virtual ICollection<TLogin> Logins { get; private set; }
        public virtual TGroup Group { get; set; }
        public virtual TKey Id { get; set; }
        public virtual string UserName { get; set; }
        public IdentityUser()
        {
            this.Claims = new List<TClaim>();
            this.Logins = new List<TLogin>();
        }
    }
