    public class MyXyzHub : Hub
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MessageRepository _messageRepository;
        public MyXyzHub(UserManager<ApplicationUser> userManager,
            MessageRepository messageRepository)
        {
            _userManager = userManager;
            _messageRepository= messageRepository;
        }
        public void sendMessage(string message)
        {
            var user = _userManager.FindByIdAsync(...
            _messageRepository.CreateAndSave(new Message
            {
                Content = message, UserId = user.Id 
            });
            Clients.All.receiveMessage(message, user.Name);
        }
    }
