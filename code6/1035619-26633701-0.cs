    public class MyServices : Service
    {
        public IDependency Dependency { get; set; }
    
        public object Any(Request request)
        {
            Dependency.Exec(request, base.SessionAs<CustomUserSession>());
        }
    }
