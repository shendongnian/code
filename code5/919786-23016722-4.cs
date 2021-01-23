    // This is the Service Contract and can live in the Model
    public class IAuthService {
        void AssertCurrentUserIsAdminOrGlobalAdmin();
        void AssertIsUserAdminOrGlobalAdmin(Guid userId,int instanceId);
    }    
    // This is the Component, which provides the Service, and is part
    // of the Web/HTTP-specific project. It is wired up via IoC/DI from
    // the large context of the application.
    public class Auth: IAuthService {
        public void AssertCurrentUserIsAdminOrGlobalAdmin() {
           // This one already knows the applicable HTTP/User Context
        }
        public void AssertIsUserAdminOrGlobalAdmin(Guid userId,int instanceId) {
           // Do whatever
        }
    }
  
    // This Component is part of the Model
    public class UserInstanceService
    {
        // IoC dependencies
        IRepository<UserInstance> userInstanceRepository;
        IAuthService authService;
    }
