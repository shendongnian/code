        /* 
         * This code was not fully tested and it is not optimized
         * It doesn't fully managed the lifetimescope of the object and memory leak may appear
         */
        internal class FixedFactoryRegistrationSource : IRegistrationSource
        {
            internal class FixedFactory<T>
            {
                public FixedFactory(T instance)
                {
                    this._instance = instance;
                }
                private readonly T _instance;
                public T GetInstance()
                {
                    return this._instance;
                }
            }
            public FixedFactoryRegistrationSource(ContainerBuilder builder)
            {
                builder.RegisterGeneric(typeof(FixedFactory<>)).As(typeof(FixedFactory<>));
            }
            public Boolean IsAdapterForIndividualComponents
            {
                get { return true; }
            }
            public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
                                                                        Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
            {
                IServiceWithType serviceWithType = service as IServiceWithType;
                if (serviceWithType == null || !serviceWithType.ServiceType.IsGenericType)
                {
                    yield break;
                }
                if (serviceWithType.ServiceType.GetGenericTypeDefinition() != typeof(Func<>))
                {
                    yield break;
                }
                Type elementType = serviceWithType.ServiceType.GetGenericArguments()[0];
                Type fixedFactoryType = typeof(FixedFactory<>).MakeGenericType(elementType);
                Service fixedFactoryService = serviceWithType.ChangeType(fixedFactoryType);
                MethodInfo getInstanceMethod = typeof(FixedFactory<>).MakeGenericType(elementType).GetMethod("GetInstance");
                foreach (IComponentRegistration registration in registrationAccessor(fixedFactoryService))
                {
                    yield return RegistrationBuilder.ForDelegate(typeof(Func<>).MakeGenericType(elementType), (c, p) =>
                                                    {
                                                        // /!\ disposal of this object is not managed
                                                        Object fixedFactory = c.ResolveComponent(registration, p);
                                                        return getInstanceMethod.CreateDelegate(typeof(Func<>)
                                                                                .MakeGenericType(elementType), fixedFactory);
                                                    })
                                                    .As(service)
                                                    .Targeting(registration)
                                                    .CreateRegistration();
                }
            }
        }
