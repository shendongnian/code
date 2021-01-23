    public interface IObjFactory
    {
        object Create(Type type);
    }
    public class FactoryCreatedComponent
    {
    }
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<FactoryCreatedComponent>(),
                Component.For<IObjFactory>().AsFactory(new TypeBasedCompenentSelector()));
        }
    }
    public class TypeBasedCompenentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override Type GetComponentType(MethodInfo method, object[] arguments)
        {
            return (Type) arguments[0];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new Installer());
            var factory = container.Resolve<IObjFactory>();
            
            var component = factory.Create(typeof (FactoryCreatedComponent));
            Debug.Assert(typeof(FactoryCreatedComponent) == component.GetType());
        }
    }
