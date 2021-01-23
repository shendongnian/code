    public class DelegatesUser
    {
        DelegatesClass ds;
        public DelegatesUser(DelegatesClass ds)
        {
            this.ds = ds;
            //...
        }
    
        public SetUserMode(int mode)
        {
            // use "ds" passed in constructor instead of new DelegatesClass();
            ds.SetMode(mode);
    
            //...
        }
    }
