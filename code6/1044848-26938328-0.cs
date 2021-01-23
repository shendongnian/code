    public class EDClaim : IdentityUserClaim<string>
    {
    }  
    public class EDLogin : IdentityUserLogin<string>
    {
    }
    [Table("Roles", Schema = "ED")]
    public class Role : IdentityRole<string, RoleUserAssociation>
    {
        [Required, Column("DisplayName")]
        public string DisplayName { get; set; }
        [Required, Column("Created")]
        public DateTime Created { get; set; }
        [Required, Column("Updated")]
        public DateTime Updated { get; set; }
        [Required, Column("Deleted")]
        public bool Deleted { get; set; }
    }  
    [Table("RoleUserAssociations", Schema = "ED")]
    public class RoleUserAssociation : IdentityUserRole<string>
    {
        //
        //  Due to Identity 2 the Id needs to of string type
        //
        [Key]
        [Required]
        public string ID { get; set; }
        //[Required, Column("User_Id")]
        //public User User { get; set; }
        //[Required, Column("Role_Id")]
        //public Role Role { get; set; }
        [Required, Column("Created")]
        public DateTime Created { get; set; }
        [Required, Column("Updated")]
        public DateTime Updated { get; set; }
        [Required, Column("Deleted")]
        public bool Deleted { get; set; }
    }  
    [Table("Users", Schema = "ED")]
    public class User : IdentityUser<string, EDLogin, RoleUserAssociation, EDClaim>
    {
        // This is needed for the new Identity 2 framework
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required, Column("Municipality_Id")]
        public Municipality Municipality { get; set; }
        public string PasswordSalt { get; set; }
        [Required, Column("FirstName")]
        public string FirstName { get; set; }
        [Required, Column("LastName")]
        public string LastName { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Required, Column("Created")]
        public DateTime Created { get; set; }
        [Required, Column("Updated")]
        public DateTime Updated { get; set; }
        [Required, Column("Deleted")]
        public bool Deleted { get; set; }
        public bool Complete { get; set; }
        [Required]
        public DateTime Activated { get; set; }
    }
