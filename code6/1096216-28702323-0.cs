       public static void AllowResolvingFuncFactories(this ContainerOptions options)
        {
            options.Container.ResolveUnregisteredType += (s, e) =>
            {
                var type = e.UnregisteredServiceType;
                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Func<>))
                {
                    return;
                }
                Type serviceType = type.GetGenericArguments().First();
                InstanceProducer registration = options.Container.GetRegistration(serviceType, true);
                Type funcType = typeof(Func<>).MakeGenericType(serviceType);
                var factoryDelegate = Expression.Lambda(funcType,
                    registration.BuildExpression()).Compile();
                e.Register(Expression.Constant(factoryDelegate));
            };
        }
