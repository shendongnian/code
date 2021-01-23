    abstract class BaseService 
    {    
        protected IContext Context {get; private set;}
    
        public BaseService(IContext context)
        {
                Context = context;
        }
    }
    public interface IContext
    {
        Tenant GetTenant();
    }
