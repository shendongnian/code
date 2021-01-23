    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        private HttpContext Context; 
        public HttpContextLifetimeManager(HttpContext context){
            this.Context = context;
        }
        public override object GetValue()
        {
            return Context.Items[typeof(T).AssemblyQualifiedName];
        }
    
        public override void SetValue(object newValue)
        {
            Context.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }
    
        public override void RemoveValue()
        {
            Context.Items.Remove(typeof(T).AssemblyQualifiedName);
        }
    
        public void Dispose()
        {
            RemoveValue();
        }
    }
