    public class User
    {
        // other properties omitted
        public virtual List<UserRole> UserRoles { get; set; }
    }
    
    public class Roles
    {
        // other properties omitted
        public virtual List<UserRole> UserRoles { get; set; }
    }
    
    public class UserRole
    {
        public int Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
