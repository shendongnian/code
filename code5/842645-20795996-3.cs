    public class UserRepository : GenericRepository<User>
    {
        // Now the User repository has all the methods of the Generic Repository
        // with addition to something a bit more specific
        public User GetByEmail(string email)
        {
            // ..
        }
    }
