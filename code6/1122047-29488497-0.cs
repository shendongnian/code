    var localEventType = typeof(IFirstEvent);
    builder.RegisterAssemblyTypes(this.assemblies)
          .AssignableTo(localEventType)
          .Keyed(ProxyBuilder.ProxyKey, localEventType)
          .InstancePerRequest(); 
    builder.Register(c =>
    {
       Type enumerableEventType = typeof(IEnumerable<>).MakeGenericType(localEventType);
       IEnumerable implementations = (IEnumerable)c.ResolveKeyed(ProxyBuilder.ProxyKey, 
                                                                 enumerableEventType);
       
       var proxy = MultiInterfaceProxy.For(localEventType, 
                                           implementations);
    });
