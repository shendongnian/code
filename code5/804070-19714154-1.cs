        public class EFUserRepository: EFRepository<User>, IUserRepository {
        public EFUserRepository(IUnitOfWork context)
            : base(context) { }
        protected override DbSet<User> Table {
            get { return Context.User; }
        }
        
        public User Find(string email) {
            return Table.FirstOrDefault(u => u.Email == email);
        }
        public bool Validate(string email, string password) {
            string passwordHash = Cryptography.GenerateHash(password);
            User user = Find(email);
            return user != null && user.Password == passwordHash;
        }
    
