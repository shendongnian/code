    public class BootstrapperClass : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SomeImplementation>().As<ISomeInterface>();            
        }
    }
