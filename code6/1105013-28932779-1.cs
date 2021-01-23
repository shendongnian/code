        public static object CreateInstance(Type type, bool genParam)
        {
            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (!genParam || constructors.Any(x => !x.GetParameters().Any()))
            {
                return Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { }, null);
            }
            
            foreach (var constructor in constructors.Where(x => x.GetParameters().Any()))
            {
                return constructor.Invoke(constructor.GetParameters().Select(x => CreateInstance(x.ParameterType, true)).ToArray());
            }
            return null;
        }
