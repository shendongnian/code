    public class InterfaceAndClassFactoryBindingGenerator : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            if (!type.IsInterface)
            {
                throw new ArgumentOutOfRangeException("type", type, "is not an interface, but only interfaces are supported");
            }
            Type classImplementingTheFactoryInterface = type.Assembly.GetTypes()
                .Where(t => t.IsClass)
                .SingleOrDefault(type.IsAssignableFrom);
            if (classImplementingTheFactoryInterface == null)
            {
                bindingRoot.Bind(type).ToFactory();
            }
            else
            {
                bindingRoot.Bind(type).To(classImplementingTheFactoryInterface);
            }
        }
    }
    IKernel kernel = new StandardKernel();
    kernel.Bind(services => services
        .From(AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => a.FullName.Contains("MyProject")
                        && !a.FullName.Contains("Tests")))
        .SelectAllInterfaces()
        .EndingWith("Factory")
        .BindWith<InterfaceAndClassFactoryBindingGenerator>());
