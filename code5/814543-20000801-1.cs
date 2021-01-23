    private Dictionary<Type, Func<PresentationAbstractClass>> factory = 
        new Dictionary<Type, Func<PresentationAbstractClass>>
        {
            { typeof(ConcreteDomainClass1), () => new ConcretePresentationClass1() },
            { typeof(ConcreteDomainClass2), () => new ConcretePresentationClass2() },
            ....
        };
    public PresentationAbstractClass ObtainPresentationClassFromDomainClass(Type type)
    {
        return factory[type]();
    }
        
