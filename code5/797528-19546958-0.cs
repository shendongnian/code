    public class UserRepository()
    {
        Sqlcontext _context;
        void UpdateUser(User user)
        {
           _context.Users.Add(user);
        }
    }
