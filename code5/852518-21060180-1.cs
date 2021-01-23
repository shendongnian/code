    public class AccountRepository : IAccountRepository
    {
        public async Task AuthenticateAsync(string username, string password)
        {
            ISession session = null;
            Task<Mabna.AccountsSDK.IAccount> objAccount;
            var objAccountsSdk = new Mabna.AccountsSDK.Client(session);
            await objAccountsSdk.AccountManager.AuthenticateAsync(username, password);
        }
    
        public async Task RegisterAsync(string username, string password, AccountType accounttype)
        {
            ISession session = null;
            Task<Mabna.AccountsSDK.IAccount> objAccount;
            var objAccountsSdk = new Mabna.AccountsSDK.Client(session);
            await objAccountsSdk.AccountManager.RegisterAsync(username, password,accounttype);
        }
    }
