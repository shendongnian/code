    unityContainer.RegisterType<Music>(new InjectionConstructor(
        new Album("Non-singleton", "Non-singleton")));
    unityContainer.RegisterType<Music>(new ContainerControlledLifetimeManager());
    public class ClearInjectionConstructor : InjectionMember
    {
        public override void AddPolicies(Type serviceType, 
            Type implementationType, 
            string name, 
            Microsoft.Practices.ObjectBuilder2.IPolicyList policies)
        {
            policies.Clear<IConstructorSelectorPolicy>(
                new NamedTypeBuildKey(implementationType, name));
        }
    }
