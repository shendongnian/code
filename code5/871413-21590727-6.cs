    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetUsersByRole(string role);
    }
