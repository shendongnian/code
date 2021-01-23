    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    
        public ICollection<UserRoles> UserRoles { get; set; }
    }
    
    [Table("webpages_Roles")]
    public class UserRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
