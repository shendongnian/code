    public class AuditLogService
    {
        private readonly IUserContext userContext;        
        public AuditLogService(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public void AddApplicationSignIn()
        {
            var user = this.userContext.GetCurrentUser();
             //... add user to some log
        }
    }
