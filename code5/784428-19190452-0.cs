    public class DinnerEventRepository : IDinnerEventRepository
    {
        MadklubContext _context = new MadklubContext();
    
        public void Save()
        {
            _context.SaveChanges();
        }  
        public DinnerEventRepository( MadklubContext context = null )
        {
            _context = context ?? new MadklubContext();
        }      
    }
    public class UserRepository //: IUserRepository
    {
        MadklubContext _context = new MadklubContext();
    
        public void Save()
        {
            _context.SaveChanges();
        }  
        public UserRepository( MadklubContext context = null )
        {
            _context = context ?? new MadklubContext();
        }      
    }
    public class RsvpUnitOfWork // come up with a better name
    {
        MadklubContext _context = new MadklubContext();
    
        public DinnerEventRepository DinnerEventRepo { get; private set; }
        public UserRepository UserRepo { get; private set; }
    
        public RsvpUnitOfWork()
        {
            DinnerEventRepo = new DinnerEventRepository( _context );
            UserRepo = new UserRepository( _context );
        }
    
        public void Save()
        {
            _context.SaveChanges();
        }
    }
