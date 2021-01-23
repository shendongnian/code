    public class UnitOfWorkPds : IUnitOfWorkPds, IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager;
        public UserManager<ApplicationUser> UserManager
        {
            get
            {
    
                if (this.userManager == null)
                {
                    this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                }
                return userManager;
            }
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(this.userManager != null)
                { this.userManager.Dispose(); }                  
                context.Dispose();
            }
            this.disposed = true;
        }
    
        public void Dispose()
        {
            Dispose(true);
           GC.SuppressFinalize(this);
        }
        // Disposable types implement a finalizer.
        ~UnitOfWorkPds()
        {
            Dispose(false);
        }
    }
