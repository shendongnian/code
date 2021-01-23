     using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity;
        using System.Linq;
    
    class Program
    {
        
        private static void Main(string[] args)
        {
            UsersContext context = new UsersContext();
            var user = new UserProfile() { UserName = "Codebased"};
            context.UserProfiles.Add(user);
            context.SaveChanges();
    
            context.Employee.Add(new Employee() { EmployeeName = "Mr. Codebased", UserID = user.UserId });
            context.SaveChanges();
    
            var userProfile = context.Employee.Include("User").FirstOrDefault().User;
    
        }
    
        public class UsersContext : DbContext
        {
            public UsersContext()
                : base()
            {
            }
    
            public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<Employee> Employee { get; set; }
        }
    
        [Table("UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string UserName { get; set; }
        }
    
        [Table("Employee")]
        public class Employee
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
          
            public int UserID { get; set; }
            public UserProfile User { get; set; }
        }
    
    }
