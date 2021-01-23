        public static List<Type> GetTypes<T>()
        {
            var results = new List<Type>();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(t => t.IsAbstract == false
                        && (typeof(T).IsInterface == false || t.GetInterfaces().Contains(typeof(T)))
                        && (typeof(T).IsClass == false || t.BaseType == typeof(T)))
                    .ToList();
                results.AddRange(types);
            }
            return results;
        }
