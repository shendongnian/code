    public class Role : IRole<User>
    {
       public string Name { get; set; }
       public IList<User> Users { get; set; }
    }
