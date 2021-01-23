    public interface IRole
    {
       string Name { get; set; }
       IList<IUser> Users { get; set; }
    }
