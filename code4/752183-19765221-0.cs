    public class AppUserStore : UserStore<IdentityUser>
    {
        public AppUserStore():base(new MY_IDENTITYDBCONTEXT())
        {
            
        }
    }
