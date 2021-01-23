    public abstract GenericFactory
    {
        public abstract GenericClass CreateInstance();
    }
    
    public FactoryFoo : GenericFactory
    {
        public override GenericClass CreateInstance()
        {
            return new Foo();
        }
    }
    
    public FactoryBar : GenericFactory
    {
        public override BaseClass CreateInstance()
        {
            return new Bar();
        }
    }
