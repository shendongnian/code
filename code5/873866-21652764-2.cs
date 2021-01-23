        public class UserRepository : Repository<User>, IUserRepository
        {       
            public IQueryable<User> AllAuthorized()
            {
                // implement here
            }
    
            public IQueryable<User> AllConfirmed()
            {
               // implement here
            }
         }
