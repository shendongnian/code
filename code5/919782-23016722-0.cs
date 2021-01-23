    public class AuthService: IAuthService {
        public void AssertCurrentUserIsAdminOrGlobalAdmin() {
           // This one already knows the applicable HTTP/User Context
        }
        public void AssertIsUserAdminOrGlobalAdmin(Guid userId,int instanceId) {
           // Do whatever
        }
    }
    public class UserInstanceService
    {
        IRepository<UserInstance> userInstanceRepository;
        IAuthService authService;
    }
