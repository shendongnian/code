    [TestClass]
    public class UnityTests
    {
        [TestMethod]
        public void Cure_For_UnityNotBeingVerySmartAtBindingCircularDependentProperties()
        {
            var container = new UnityContainer();
            container.RegisterType<ISharedResource, SharedResource>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICycleA, CycleA>(new ContainerControlledLifetimeManager(), new InjectionProperty("SharedResource"));
            container.RegisterType<ICycleB, CycleB>(new ContainerControlledLifetimeManager(), new InjectionProperty("SharedResource"));
            var a = container.Resolve<ICycleA>();
            var b = container.Resolve<ICycleB>();
            container.RegisterType<ICycleA, CycleA>("buildup", new ContainerControlledLifetimeManager());
            container.RegisterType<ICycleB, CycleB>("buildup", new ContainerControlledLifetimeManager());
            
            container.BuildUp(a, "buildup");
            container.BuildUp(b, "buildup");
            Assert.IsInstanceOfType(a, typeof(CycleA));
            Assert.IsInstanceOfType(a.Dependency, typeof(CycleB));
            Assert.AreSame(a, a.Dependency.Dependency);
        }
    }
    internal interface ISharedResource { }
    class SharedResource : ISharedResource { }
    class CycleB : ICycleB
    {
        [Dependency]public ISharedResource SharedResource { get; set; }
        [Dependency]public ICycleA Dependency { get; set; }
    }
    class CycleA : ICycleA
    {
        [Dependency]public ISharedResource SharedResource { get; set; }
        [Dependency]public ICycleB Dependency { get; set; }
    }
    interface ICycleB
    {
        [Dependency]ISharedResource SharedResource { get; set; }
        [Dependency]ICycleA Dependency { get; set; }
    }
    interface ICycleA
    {
        [Dependency]ISharedResource SharedResource { get; set; }
        [Dependency]ICycleB Dependency { get; set; }
    }
