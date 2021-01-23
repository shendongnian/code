    public class ApplicationModule
    {
        public ApplicationModule(IContainer container)
        {
            container.GetNestedContainer();
            container.Configure(x =>
            {
                x.AddRegistry<ModuleSpecificRegistry>();
            });
        }
    }
