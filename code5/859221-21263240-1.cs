    class MyClassFactory
    {
        Dictionary<uint,GenericFactory> mGenericLibrary = new Dictionary<uint,GenericFactory>();
    
        public void RegisterClass(uint id, GenericFactory factory)
        {
            mGenericLibrary[id] = factory;
        }
        
        public GenericClass GetNewGenericType(uint id)
        {
             return mGenericLibrary[id].CreateInstance();
        }
    }
