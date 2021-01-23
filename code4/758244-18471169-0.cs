        public static IEnumerable<Type> CreatableTypes(this Assembly assembly)
        {
            return assembly
                .ExceptionSafeGetTypes()
                .Where(t => !t.IsAbstract)
                .Where(t => t.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Any());
        }
