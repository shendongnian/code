    public class UserRepository : IUserRepository
    {
        private YourDbContext _db;     
        public UserRepository(YourDbContext db)
        {
            _db = db;
        }
        public User GetById(int id)
        {
            return _db.Users.Find(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _db.Users.AsEnumerable();
        }
    
        public IEnumerable<User> GetUsersByRole(string role)
        {
            return _db.Users.Where(u => u.Role == role).AsEnumerable();
        }
    }
