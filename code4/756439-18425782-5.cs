    public static class ContractResolver
    {
        //NEW CHANGE: This is the new function that suppose to return the instance of parameterised constructor
        public static T Resolve<T>(string name, params ParameterOverride[] parameterOverrides)
        {
            IUnityContainer container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Containers.Default.Configure(container);
            return container.Resolve<T>(name, parameterOverrides);
        }
    }
