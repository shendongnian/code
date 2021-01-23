    public class AccountService : IAccountService
    {
        protected readonly DbContext context;
        public AccountService(DbContext context)
        {
            this.context = context;
        }
        ...
    }
