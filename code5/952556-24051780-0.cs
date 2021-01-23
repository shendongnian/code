     public abstract class RoleEntryPoint
      {
        public virtual bool OnStart()
        {
          return true;
        }
    
        public virtual void Run()
        {
          Thread.Sleep(-1);
        }
    
        public virtual void OnStop()
        {
        }
      }
