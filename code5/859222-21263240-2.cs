    public abstract GenericFactory
    {
        public abstract GenericClass CreateInstance();
    }
    
    public GenericClassSub1Factory : GenericFactory
    {
        public override GenericClass CreateInstance()
        {
            return new GenericClassSub1();
        }
    }
    
    public GenericClassSub2Factory : GenericFactory
    {
        public override BaseClass CreateInstance()
        {
            return new GenericClassSub2();
        }
    }
