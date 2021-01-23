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
        public ICollection<User> GetAll()
        {
            return _db.Users.ToList();
        }
    
        public ICollection<User> GetUsersByRole(string role)
        {
            return _db.Users.Where(u => u.Role == role).ToList();
        }
    }
