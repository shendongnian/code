    public class MyXyzHub : Hub
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public MyXyzHub(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public void sendMessage(string message)
        {
            var user = _userManager.FindByIdAsync(...
            _dbContext.Set<Message>.Create(new Message
            {
                Content = message, UserId = user.Id 
            });
            _dbContext.SaveChanges();
            Clients.All.receiveMessage(message, user.Name);
        }
    }
