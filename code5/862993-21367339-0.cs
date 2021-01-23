    public class FactoryResponseImpl : IFactoryResponse
    {
        DatabaseFactoryResponseInstance _instance;
    
        public FactoryResponseImpl()
        {
            _instance = new DatabaseFactoryResponseInstance();
        }
    
        object IFactoryResponse.instance {
        get { return (object)_instance; }
        set { 
                if (value != null)
                {
                    DatabaseFactoryResponseInstance dbInstance;
                    dbInstance = value as DatabaseFactoryResponseInstance;
                    if (dbInstance == null)
                        throw new InvalidOperationException();
    
                    _instance = dbInstance;
                }
             }
    }
