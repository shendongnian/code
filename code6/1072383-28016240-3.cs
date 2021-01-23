    public class ApplicationModule
    {
        public ApplicationModule(IContainer container)
        {
            childContainer = container.GetNestedContainer();
            childContainer.Configure(x =>
            {
                x.AddRegistry<ModuleSpecificRegistry>();
            });
        }
    }
