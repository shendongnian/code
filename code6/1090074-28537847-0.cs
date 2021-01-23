    internal class CommonConventions
    {
        public static void RegisterDefaultConventions(
            Action<Type, Type> registerMethod, 
            Assembly[] interfaceAssemblies, 
            Assembly[] implementationAssemblies, 
            Type[] excludeTypes,
            string excludeRegEx)
        {
            List<Type> interfaces = new List<Type>();
            foreach (var assembly in interfaceAssemblies)
                interfaces.AddRange(GetInterfaces(assembly));
            foreach (var interfaceType in interfaces)
            {
                if (!IsExcludedType(interfaceType, excludeTypes, excludeRegEx))
                {
                    List<Type> implementations = new List<Type>();
                    foreach (var assembly in implementationAssemblies)
                        implementations.AddRange(GetImplementationsOfInterface(assembly, interfaceType).Where(implementation => !IsExcludedType(implementation, excludeTypes, excludeRegEx)).ToArray());
                    // Prefer the default name ITypeName = TypeName
                    Type implementationType = implementations.Where(implementation => IsDefaultType(interfaceType, implementation)).FirstOrDefault();
                    if (implementationType == null)
                    {
                        // Fall back on ITypeName = ITypeNameAdapter
                        implementationType = implementations.Where(implementation => IsAdapterType(interfaceType, implementation)).FirstOrDefault();
                    }
                    if (implementationType != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Auto registration of {1} : {0}", interfaceType.Name, implementationType.Name);
                        registerMethod(interfaceType, implementationType);
                    }
                }
            }
        }
        public static void RegisterAllImplementationsOfInterface(
            Action<Type, Type> registerMethod,
            Type[] interfaceTypes,
            Assembly[] implementationAssemblies,
            Type[] excludeTypes,
            string excludeRegEx)
        {
            foreach (var interfaceType in interfaceTypes)
            {
                List<Type> implementations = new List<Type>();
                foreach (var assembly in implementationAssemblies)
                    implementations.AddRange(GetImplementationsOfInterface(assembly, interfaceType));
                foreach (var implementationType in implementations)
                {
                    if (!IsExcludedType(implementationType, excludeTypes, excludeRegEx))
                    {
                        System.Diagnostics.Debug.WriteLine("Auto registration of {1} : {0}", interfaceType.Name, implementationType.Name);
                        registerMethod(interfaceType, implementationType);
                    }
                }
            }
        }
        private static bool IsExcludedType(Type type, Type[] excludeTypes, string excludeRegEx)
        {
            return IsExcludedType(type, excludeTypes) || IsExcludedType(type, excludeRegEx) || IsExcludedType(type);
        }
        private static bool IsExcludedType(Type type, Type[] excludeTypes)
        {
            return excludeTypes.Contains(type);
        }
        private static bool IsExcludedType(Type type, string excludeRegEx)
        {
            if (string.IsNullOrEmpty(excludeRegEx)) return false;
            return Regex.Match(type.Name, excludeRegEx, RegexOptions.Compiled).Success;
        }
        private static bool IsExcludedType(Type type)
        {
            return type.GetCustomAttributes(typeof(MvcSiteMapProvider.DI.ExcludeFromAutoRegistrationAttribute), false).Length > 0;  
        }
        private static bool IsDefaultType(Type interfaceType, Type implementationType)
        {
            return interfaceType.Name.Equals("I" + implementationType.Name);
        }
        private static bool IsAdapterType(Type interfaceType, Type implementationType)
        {
            return implementationType.Name.EndsWith("Adapter") &&
                interfaceType.Name.Equals("I" + implementationType.Name.Substring(0, implementationType.Name.Length - 7));
        }
        private static IEnumerable<Type> GetInterfaces(Assembly assembly)
        {
            return assembly.GetTypes().Where(t => t.IsInterface);
        }
        private static IEnumerable<Type> GetImplementationsOfInterface(Assembly assembly, Type interfaceType)
        {
            return assembly.GetTypes().Where(t =>
                !t.IsInterface &&
                !t.IsAbstract &&
                interfaceType.IsAssignableFrom(t) &&
                t.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                    .Any(type => type.GetParameters().Select(p => p.ParameterType).All(p => (p.IsInterface || p.IsClass) && p != typeof(string))));
        }
    }
