    builder.RegisterAssemblyTypes(typeof(OurObjectContext).Assembly)
        .InNamespace("Company.Core.Services")
        .AsImplementedInterfaces()
        .InstancePerHttpRequest()
        .WithParameter(new ResolvedParameter((parameterInfo, componentContext) =>
        {
            // in predicate we select only IRepository<> types
            return parameterInfo.ParameterType.GetGenericTypeDefinition() == typeof(IRepository<>);
        }, (parameterInfo, componentContext) =>
        {
            // firstly we get a generic parameter type 
            var genericArgument = parameterInfo.ParameterType.GetGenericArguments()[0];
            // then we construct a new generic type with the parameter, suppose it's LoggingRepository<> and it's registered
            var typeToResolve = typeof(LoggingRepository<>).MakeGenericType(genericArgument);
            // resolve the type and Autofac will put it instead of IRepository<>
            return componentContext.Resolve(typeToResolve);
        }));
