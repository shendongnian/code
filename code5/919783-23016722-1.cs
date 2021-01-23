    public class Auth: IAuthService {
        public void AssertCurrentUserIsAdminOrGlobalAdmin() {
           // This one already knows the applicable HTTP/User Context
        }
        public void AssertIsUserAdminOrGlobalAdmin(Guid userId,int instanceId) {
           // Do whatever
        }
    }
    public class UserInstanceService
    {
        // IoC dependencies
        IRepository<UserInstance> userInstanceRepository;
        IAuthService authService;
    }
