    private Dictionary<Type, Func<DomainAbstractClass, PresentationAbstractClass>> factory = 
        new Dictionary<Type, Func<DomainAbstractClass, PresentationAbstractClass>>
        {
            { typeof(ConcreteDomainClass1), (x) => new ConcretePresentationClass1(x) },
            { typeof(ConcreteDomainClass2), (x) => new ConcretePresentationClass2(x) },
            ....
        };
    public PresentationAbstractClass ObtainPresentationClassFromDomainClass(DomainAbstractClass domainClass)
    {
        return factory[domainClass.GetType()](domainClass);
    }
        
