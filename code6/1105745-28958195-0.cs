        public static IEnumerable<TModule> GetModules<TModule>()
        {
            var moduleType = typeof (TModule);
            var dependencyModuleTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(moduleType)).Select(p=>(TModule)Activator.CreateInstance(p));
            return dependencyModuleTypes;
        }
