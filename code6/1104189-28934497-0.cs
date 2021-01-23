    public static class CommonContainerConfig
    {
        public static void RegisterDependencies(ContainerBuilder builder) 
        {
            builder.RegisterType<ActivitiesService>().As<IActivitiesService>();
            //etc
        }
    }
