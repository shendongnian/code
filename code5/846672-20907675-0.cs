        public static List<Type> GetClassesWhere(Func<Type, bool> evaluator)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var types = new List<Type>();
            foreach(var assembly in assemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes().Where(evaluator).ToList());
                }
                catch
                {
                }
            }
            return types;
        }
