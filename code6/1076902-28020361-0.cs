    public class MyDataManager : MarshalByRefObject, IDataManager
    {
        {...}
    
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
