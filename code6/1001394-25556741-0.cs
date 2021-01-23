    public static class ActionMethodsRegistrator
    {
        private static readonly Type ApiControllerType = typeof(IHttpController);
        public static void RegisterActionMethods(YourCustomConfig config)
        {
            // find all api controllers in executing assembly            
            var contollersTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(foundType => ApiControllerType.IsAssignableFrom(foundType));
            
            // you may also search for controllers in all loaded assemblies e.g.
            // var contollersTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(foundType => ApiControllerType.IsAssignableFrom(foundType));                
            foreach (var contollerType in contollersTypes)
            {
                // you may add more restriction here for optimization, e. g. BindingFlags.DeclaredOnly
                // I took search parameters from mvc/web api sources.
                var allMethods = contollerType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (var methodInfo in allMethods)
                {
                    var actualResponseAttrubute = methodInfo.GetCustomAttribute<ActualResponseAttribute>();
                    if (actualResponseAttrubute != null)
                    {                       
                        config.SetActualResponseType(actualResponseAttrubute.Type, contollerType.Name, methodInfo.Name);                        
                    }
                }
            }
        }
    }
