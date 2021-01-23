    public class UsersController : ApiController
    {
        private readonly IAddUserMaintenanceProcessor _addUserProcessor;
        public UsersV1Controller(IAddUserMaintenanceProcessor addUserProcessor)
        {
            _addUserProcessor = addUserProcessor;
        }
        public async Task<UserModel> Post(NewUser user)
        {
            return await _addUserProcessor.AddUserAsync(user);
        }
        // ...
    }
