    public class FooContext : DbContext
    {
        public FooContext(IDbInitializer<T> init = null, bool forceInit = false)
        {
            if(init != null)
                Database.SetInitializer(init);
            if(forceInit)
                Database.Init(true);
        }
    }
