    public class Role : IRole<User>
    {
       public string Name { get; set; }
       public IList<IUser> Users { get; set; }
    }
