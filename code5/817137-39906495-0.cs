    public Mock<IRepo> SetupGenericReserve<TBase>() where TBase : class
    {
        var mock = new Mock<IRepo>();
        var types = GetDerivedTypes<TBase>();
        var setupMethod = this.GetType().GetMethod("Setup");
        foreach (var type in types)
        {
            var genericMethod = setupMethod.MakeGenericMethod(type)
                .Invoke(null,new[] { mock });
        }
        return mock;
    }
    public void Setup<TDerived>(Mock<IRepo> mock) where TDerived : class
    {
        // Make this return whatever you want. Can also return another mock
        mock.Setup(x => x.Reserve<TDerived>())
            .Returns(new IA<TDerived>());
    }
    public IEnumerable<Type> GetDerivedTypes<T>() where T : class
    {
        var types = new List<Type>();
        var myType = typeof(T);
        var assemblyTypes = myType.GetTypeInfo().Assembly.GetTypes();
        var applicableTypes = assemblyTypes
            .Where(x => x.GetTypeInfo().IsClass 
                    && !x.GetTypeInfo().IsAbstract 
                     && x.GetTypeInfo().IsSubclassOf(myType));
        foreach (var type in applicableTypes)
        {
            types.Add(type);
        }
        return types;
    }
