    public T Proxify<T>(IGiveConstructorParametersFor<T> constructorParametersForT) {
        var options = new ProxyGenerationOptions();
        options.AddMixinInstance(new TypePresenter<T>());
        
        var pg = new ProxyGenerator();
        var sample = pg.CreateClassProxy(typeof(T),
                                         null,
                                         options,
                                         constructorParametersForT.Parameters);
        
        var typeDescriptor = (ICustomTypeDescriptor)sample;
        var properties = typeDescriptor.GetProperties();
    }
