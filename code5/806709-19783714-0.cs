    public class User
    {
       public int ID { get; set; }
       public virtual Role Role { get; set; }
    }
    public class Role
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public virtual List<User> UsersInRole { get; set; }
    } 
