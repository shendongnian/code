        public class AutoRegistredBootstrapper : DefaultNancyBootstrapper
    {
        private readonly object AutoRegisterLock = new object();
        private void AutoRegister(TinyIoCContainer container, IEnumerable<Assembly> assemblies)
        {
            var ignoreChecks = new List<Func<Type, bool>>()
            {
                t => t.FullName.StartsWith("System.", StringComparison.Ordinal),
                t => t.FullName.StartsWith("Microsoft.", StringComparison.Ordinal),
                t => t.IsPrimitive(),
                t => (t.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length == 0) && !(t.IsInterface() || t.IsAbstract()),
                t => t.Assembly == typeof(NancyEngine).Assembly
            };
            lock (AutoRegisterLock)
            {
                var thisType = this.GetType();
                var types = assemblies.SelectMany(a => AssemblyExtensions.SafeGetTypes(a))
                    .Where(type => (type.DeclaringType != thisType)
                                   && !type.IsGenericTypeDefinition())
                    .Where(t => !ignoreChecks.Any(check => check(t)))
                    .ToList();
                var assignebleTypes =
                    types.Where(
                            type =>
                                type.IsClass() && (type.IsAbstract() == false) && (type != thisType))
                        .Select(t =>
                        {
                            // be careful with side effects in linq
                            container.Register(t);
                            return t;
                        })
                        .Where(implementationType => implementationType.GetTypeInfo().ImplementedInterfaces.Any() || implementationType.BaseType != typeof(Object))
                        .ToList();
                var abstractInterfaceTypes = types.Where(type => ((type.IsInterface() || type.IsAbstract())));
                foreach (var abstractInterfaceType in abstractInterfaceTypes)
                {
                    var localType = abstractInterfaceType;
                    var implementations =
                        assignebleTypes.Where(implementationType => localType.IsAssignableFrom(implementationType)).ToList();
                    if (implementations.Count > 1)
                    {
                        if (implementations.Count != implementations.Distinct().Count())
                        {
                            var fullNamesOfDuplicatedTypes = string.Join(",\n",
                                implementations.GroupBy(i => i).Where(j => j.Count() > 1).Select(j => j.Key.FullName));
                            throw new ArgumentException($"types: The same implementation type cannot be specified multiple times for {abstractInterfaceType.FullName}\n\n{fullNamesOfDuplicatedTypes}");
                        }
                        foreach (var implementationType in implementations)
                        {
                            container.Register(abstractInterfaceType, implementationType, implementationType.FullName);
                        }
                    }
                    var firstImplementation = implementations.FirstOrDefault();
                    if (firstImplementation != null)
                    {
                        container.Register(abstractInterfaceType, firstImplementation);
                    }
                }
            }
        }
        protected override IEnumerable<Func<Assembly, bool>> AutoRegisterIgnoredAssemblies
        {
            get
            {
                return DefaultAutoRegisterIgnoredAssemblies.Concat(new Func<Assembly, bool>[]
                {
                    asm => asm.FullName.StartsWith("ICSharpCode.", StringComparison.Ordinal),
                    asm => asm.FullName.StartsWith("Ionic.", StringComparison.Ordinal),
                    asm => asm.FullName.StartsWith("CommandLine,", StringComparison.Ordinal)
                    // ADD THE REST OF 3D party libs that you don't use as dependencies 
                });
            }
        }
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var ignoredAssemblies = this.AutoRegisterIgnoredAssemblies.ToList();
            var asmsForProcessing = currentDomainAssemblies.Where(a => !ignoredAssemblies.Any(ia => ia(a))).ToList();
            AutoRegister(container, asmsForProcessing);
        }
    }
