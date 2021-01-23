    public class RepositoryContainer : IRepositoryContainer
    {
      private readonly IContext _context;
      
      private IUserRepository _userRepository;
      private IUserProfileRepository _userProfileRepository;
      
      public RepositoryContainer(IContext context)
      {
        if (context == null) throw new ArgumentNullException("context");
        
        _context = context;
      }
      
      public IUserRepository UserRepository
      {
        get 
        { 
          return _userRepository = _userRepository ?? new UserRepository(_context); 
        }
      }
      
      public IUserProfileRepository UserProfileRepository
      {
        get
        {
          return _userProfileRepository = _userProfileRepository ?? new UserProfileRepository(_context);
        }
      }
    }
