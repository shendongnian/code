    namespace qubis.booking.WebApp.App_Code.Identity
    {
        public class UserServiceWrapper : IUserStore<ApplicationUserWrapper>, 
                                          IUserPasswordStore<ApplicationUserWrapper>, 
                                          IUserLoginStore<ApplicationUserWrapper>
        {
            public IUserRepository UserRepos { get; set; } // My own Interface.
            public UserServiceWrapper(IUserRepository userRepo)
            {
                UserRepos = userRepo;
            }
    
    
            public async Task CreateAsync(ApplicationUserWrapper user)
            {
                UserRepos.Insert(user.RealUser);
            }
    
            public async Task<ApplicationUserWrapper> FindByIdAsync(string userId)
            {
                var appUser = UserRepos.FindByUserName(userId);
                ApplicationUserWrapper wrappedUser;
                if (appUser != null)
                {
                    wrappedUser = new ApplicationUserWrapper(appUser);
                }
                else
                    wrappedUser = null;
                return wrappedUser;
            }
