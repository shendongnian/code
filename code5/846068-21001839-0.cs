    public interface ISomeComponent
    {
    }
    public interface ISomeOtherComponent
    {
    }
    public class SomeComponent : ISomeComponent
    {
        public SomeComponent(ISomeOtherComponent someOtherComponent)
        {
        }
    }
    public class SomeOtherComponent : ISomeOtherComponent
    {
    }
    public class Legal
    {
        public Legal(ISomeComponent component)
        {
        }
    }
    public class Illegal
    {
        public Illegal(ISomeOtherComponent component)
        {
        }
    }
    public class SubDependencyResolver : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
                               DependencyModel dependency)
        {
            // If not an ISomeotherComponent or SomeOtherComponent is resolved ignore.
            if (dependency.TargetType != typeof (ISomeOtherComponent) && dependency.TargetType != typeof (SomeOtherComponent)) return false;
            // check if we are resolving for SomeComponent
            if (model.Implementation == typeof (SomeComponent)) return false;
            // We are resolving for a different component then SomeComponent.
            Debug.Assert(false);
            return false;
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
                              DependencyModel dependency)
        {
            // We will never actually resolve the component, but always use the standard SubDependencyResolver, as Can resolve always returns false;
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new SubDependencyResolver());
            container.Register(
                Component.For<ISomeOtherComponent>().ImplementedBy<SomeOtherComponent>(),
                Component.For<ISomeComponent>().ImplementedBy<SomeComponent>(),
                Component.For<Legal>()
    //          Component.For<Illegal>() uncommenting this line will assert.
                );
        }
    } 
