    [Table("UsersInRoles")]
    public class UsersInRoles
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("UserMaster")]
        public int UserId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public UserMaster UserMaster { get; set; }
        public Role Role { get; set; }
    }
