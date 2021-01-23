    public interface IUserRepository
    {
        User GetById(int id);
        ICollection<User> GetAll();
        ICollection<User> GetUsersByRole(string role);
    }
