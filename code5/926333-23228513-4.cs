    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
    
        public UserManager<ApplicationUser> UserManager { get; private set; }
    
        public AccountController()
            : this(new UnitOfWork<MyDbContext>())
        {
        }
    
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;    
            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(unitOfWork.GetDbContext<MyDbContext>());
            this.UserManager = new UserManager<ApplicationUser>(store);
        }
        ...
    }
