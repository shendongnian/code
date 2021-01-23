    public class UserManagerProvider : IUserManagerProvider
    {
        private readonly IContext _context;
        public UserManagerProvider(IContext context)
        {
            _context = context;
        }
        public IUserManager Create(User currentUserRole)
        {
            if (currentUserRole == "User A")
                return _context.Kernel.Get<UserManagerA>();
            if (currentUserRole == "User B")
                return _context.Kernel.Get<UserManagerB>();
        }
    }
