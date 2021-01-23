    kernel.Bind(x => x
        .FromThisAssembly()
        .SelectAllClasses()
        .InheritedFrom(typeof(IQueryHandler<,>))
        .BindSingleInterface()
        .Configure(QueryHandlerBindingConfigurator.Configure));
    public class QueryHandlerBindingConfigurator
    {
        private static readonly string DefaultImplementationName =
            RetrieveDefaultImplementationName();
        public static void Configure(
            IBindingWhenInNamedWithOrOnSyntax<object> syntax,
            Type serviceType)
        {
            if (!IsDefaultImplementation(serviceType))
            {
                int indexOfSuffix = serviceType.Name.IndexOf(
                                        DefaultImplementationName,
                                        StringComparison.InvariantCultureIgnoreCase);
                if (indexOfSuffix > 0)
                {
                    // specific handler
                    string route = serviceType.Name.Substring(0, indexOfSuffix);
                    syntax.When(x => route == 
                              syntax.Kernel.Get<IMyContext>().CustomRouteValue);
                }
                else
                {
                    // invalid name!
                    throw CreateExceptioForNamingConventionViolation(serviceType);
                }
            }
            syntax.InRequestScope();
        }
        private static bool IsDefaultImplementation(Type serviceType)
        {
            return serviceType.Name.StartsWith(DefaultImplementationName, StringComparison.InvariantCultureIgnoreCase);
        }
        private static Exception CreateExceptioForNamingConventionViolation(Type type)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                "The type {0} does implement the {1} interface, but does not adhere to the naming convention: " +
                Environment.NewLine + "-if it is the default handler, it should  be named {2}" +
                Environment.NewLine +
                "-if it is an alternate handler, it should be named FooBar{2}, where 'FooBar' is the route key",
                type.Name,
                typeof(IQueryHandler<,>).Name,
                DefaultImplementationName);
            return new ArgumentOutOfRangeException("type", message);
        }
        private static string RetrieveDefaultImplementationName()
        {
            // the name is something like "IQueryHandler`2", we only want "QueryHandler"
            string interfaceName = typeof(IQueryHandler<,>).Name;
            return interfaceName.Substring(1, interfaceName.IndexOf("`", StringComparison.InvariantCulture) - 1);
        }
    }
