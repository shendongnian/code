    public class SomeService : ISomeService
    {
        private readonly Context _context;
        private readonly IUserRole _userRoleRepository;
        public SomeService(Context context, IUserRole userRoleRepository)
        {
            _context = context;
            _userRoleRepository = userRoleRepository;
        }
    
        public virtual User GetUser(string username, string password)
        {
            User systemUser = new User();         
            systemUser = (from u in _context.Users where u.Username == username && u.UserPassword == password select u).FirstOrDefault();
            List<IUserRole> roleList = _userRoleRepository.GetRoles(systemUser.UserID);
            systemUser._roles = roleList;          
    
            return systemUser;
        }
    }
