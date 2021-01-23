    class MyClassFactory
    {
        Dictionary<uint,GenericFactory> mGenericLibrary = new Dictionary<uint,GenericFactory>();
    
        public void RegisterFactory(uint id, GenericFactory factory)
        {
            mGenericLibrary[id] = factory;
        }
        
        public GenericClass GetNewGenericType(uint id)
        {
             return mGenericLibrary[id].CreateInstance();
        }
    }
    void Example()
    {
        var factory = new MyClassFactory();
        factory.RegisterFactory(1, new GenericClassSub1Factory());
        factory.RegisterFactory(2, new GenericClassSub2Factory());
        factory.RegisterFactory(3, new GenericClassSub3Factory());
        var item1 = factory.GetNewGenericType(1); //Contains a new GenericClassSub1;
        var item2 = factory.GetNewGenericType(2); //Contains a new GenericClassSub2;
        var item3 = factory.GetNewGenericType(3); //Contains a new GenericClassSub3;
        
    }
