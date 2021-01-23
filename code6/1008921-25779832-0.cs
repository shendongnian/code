            IKernel kernel = new StandardKernel();
            IList<Type> implementedFactoryInterfaces = new List<Type>();
            kernel.Bind(services => services
                .From(AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(a => a.FullName.Contains("MyProject")
                             && !a.FullName.Contains("Tests")))
                .SelectAllClasses()
                .EndingWith("Factory")
                .Where(classFactoryType =>
                {
                    implementedFactoryInterfaces.Add(classFactoryType.GetInterfaces().Single());
                    return true;
                })
                .BindDefaultInterface());
            kernel.Bind(services => services
                .From(AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(a => a.FullName.Contains("MyProject")
                             && !a.FullName.Contains("Tests")))
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .Excluding(implementedFactoryInterfaces)
                .BindToFactory());
