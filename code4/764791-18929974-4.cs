    [Table("UserMaster")]
    public class UserMaster  
    {
        public UserMaster()
        {
            this.Roles = new List<Role>();
        }
        [Key]    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<UsersInRoles> UsersInRoles { get; set; }
     } 
    [Table("Role")]
    public class Role 
    {
        public Role()
        {
            this.Users = new List<UserMaster>();
        }
        public int RoleId{ get; set; }
        public string Name{ get; set; }
        public ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
