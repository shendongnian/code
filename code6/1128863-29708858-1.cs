    public class CurrentWebUserService : ICurrentUserService {
        // implement interface members 
        public CurrentWebUserService(HttpContext context) { ... }
        public string UserName { get { ... } } 
        // etc.
    }
    
    // maybe you want a stub service to inject while unit testing.
    public class CurrentUserServiceStub : ICurrentUserService {
    
    }
    // data 
    public class MyDaoService {
        public DaoService(ICurrentUserService currentUser) { ... }
    }
