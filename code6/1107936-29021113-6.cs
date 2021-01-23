    public class UserManagerProvider : IUserManagerProvider
    {
        private readonly IContext _context;
        public UserManagerProvider(IContext context)
        {
            _context = context;
        }
        public IUserManager Create(User currentUser)
        {
            if (currentUser.Role == "User A")
                return _context.Kernel.Get<UserManagerA>();
            if (currentUser.Role == "User B")
                return _context.Kernel.Get<UserManagerB>();
            // Or bind and resolve by name
            // _context.Kernel.Get<IUserManager>(currentUser.Role);
        }
    }
