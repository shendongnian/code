    public class User : IUser
    {
        public User()
        {
            this.LastLoginDate = DateTime.UtcNow;
            this.DateCreated = DateTime.UtcNow;
        }
        public User(string userName)
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserName = userName;
            this.CreatedBy = this.Id;
            this.LastLoginDate = DateTime.UtcNow;
            this.DateCreated = DateTime.UtcNow;
            this.IsApproved = true;
        }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredUserName")]
        public string UserName { get; set; }
        
        public string Id { get; set; }
        [Required] public string CompanyId { get; set; }
        [Required] public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime LastLoginDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredTitle")]
        public string Title { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredFirstName")]
        public string Forename { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredLastName")]
        public string Surname { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredEmail")]
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Photo { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Bio { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredCredentialId")]
        public string CredentialId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RequiredSecurityCode")]
        public bool IsLockedOut { get; set; }
        public bool IsApproved { get; set; }
        [Display(Name = "Can only edit own assets")]
        public bool CanEditOwn { get; set; }
        [Display(Name = "Can edit assets")]
        public bool CanEdit { get; set; }
        [Display(Name = "Can download assets")]
        public bool CanDownload { get; set; }
        [Display(Name = "Require approval to upload assets")]
        public bool RequiresApproval { get; set; }
        [Display(Name = "Can approve assets")]
        public bool CanApprove { get; set; }
        [Display(Name = "Can synchronise assets")]
        public bool CanSync { get; set; }
        public bool AgreedTerms { get; set; }
        public bool Deleted { get; set; }
    }
    public class UserContext : IdentityStoreContext
    {
        public UserContext(DbContext db)
            : base(db)
        {
            this.Users = new UserStore<User>(this.DbContext);
        }
    }
    public class UserDbContext : IdentityDbContext<User, UserClaim, UserSecret, UserLogin, Role, UserRole>
    {
    }
