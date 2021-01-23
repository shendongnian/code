    public interface IApiExampleController
    {
        IEnumerable<User> GetAllUsers();
    }
    
    public class ApiExampleController : ApiController, IApiExampleController
    {
        private readonly IEFContext _context;
    
        public ApiExampleController()
        {
            _context = new EFContext();
        }
    
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
