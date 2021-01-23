    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual DbUserRoles DbUserRoles { get; set; }
    }
