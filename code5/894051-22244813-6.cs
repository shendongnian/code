    public interface IApiDTOExampleController
    {
        IEnumerable<UserDTO> GetAllUsers();
    }
    
    public class ApiDTOExampleController : ApiController, IApiDTOExampleController
    {
        private readonly IEFContext _context;
    
        public ApiDTOExampleController()
        {
            _context = new EFContext();
        }
    
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _context.Users.Select(x => new UserDTO { Id = x.Id, Name = x.Name }).ToList();
        }
    }
