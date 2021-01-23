    public class Repository1
    {
        public IYourDbContext DbContext { get; private set; }
    
        public Repository1()
        {
            // How it's probably have been before
            // DbContext = new YourDbContext();
    
            // Getting DbContext from IoC container
            DbContext = (IYourDbContext) DependencyResolver.Current.GetService(typeof (IYourDbContext));
        }
    }
