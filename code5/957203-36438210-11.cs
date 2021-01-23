    public class AddUserMaintenanceProcessor : IAddUserMaintenanceProcessor
    {
        private readonly IAddUserQueryProcessor _queryProcessor;
        private readonly ILog _logger;
        private readonly IAutoMapper _mapper;
        public AddUserMaintenanceProcessor(
            IAddUserQueryProcessor queryProcessor,
            ILogManager logManager,
            IAutoMapper mapper)
        {
            _queryProcessor = queryProcessor;
            _logger = logManager.GetLog(typeof(AddUserMaintenanceProcessor));
            _mapper = mapper;
        }
        public async Task<UserModel> AddUserAsync(NewUser newUser)
        {
            _logger.Info($"Adding new user {newUser.UserName}");
            // Map the NewUser object to a User object
            var user = _mapper.Map<User>(newUser);
            // Persist the user to a medium unknown to this class, using the query processor,
            // which in turn returns a User object
            var addedUser = await _queryProcessor.AddUserAsync(user);
            // Map the User object back to UserModel to return to requester
            var userModel = _mapper.Map<UserModel>(addedUser);
            _logger.Info($"User {userModel.UserName} added successfully");
            return userModel;
        }
    }
