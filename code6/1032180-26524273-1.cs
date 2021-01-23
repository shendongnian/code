    interface NewInterface
    {
        string NewMethod();
    }
    public BaseClass
    {
       ...
    }
    
    public DerivedClass : BaseClass, NewInterface
    {
        public string NewMethod
        {
           ...
        }
    }
