    public class MyModule: Autofac.Module
    {
        public override void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<MyConcreteType>()
                   .As<IMyInterface>()
                   .WithMetadata<IRegisteredByModuleMetadata>(m =>
                        m.For(am => am.RegisteringModuleType, GetType());;
        }
    }
