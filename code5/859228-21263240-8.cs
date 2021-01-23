    class MyClassFactory
    {
        Dictionary<uint,Func<GenericClass>> mGenericLibrary = new Dictionary<uint,Func<GenericClass>>();
    
        public void RegisterFactory(uint id, Func<GenericClass> factory)
        {
            mGenericLibrary[id] = factory;
        }
        
        public GenericClass GetNewGenericType(uint id)
        {
             //This could be one line, but i think mGenericLibrary[id]() looks too weird.
             Func<GenericClass> factory = mGenericLibrary[id];
             return factory();
        }
    }
        void Example()
    {
        var factory = new MyClassFactory();
        factory.RegisterFactory(1, () => new GenericClassSub1());
        factory.RegisterFactory(2, () => new GenericClassSub2());
        factory.RegisterFactory(3, () => new GenericClassSub3());
        var item1 = factory.GetNewGenericType(1); //Contains a new GenericClassSub1;
        var item2 = factory.GetNewGenericType(2); //Contains a new GenericClassSub2;
        var item3 = factory.GetNewGenericType(3); //Contains a new GenericClassSub3;
    }
