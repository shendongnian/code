    public partial class DbUserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        [Required]
        [StringLength(30)]
        public string UserRole { get; set; }
    }
