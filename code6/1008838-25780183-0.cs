    public class Dependency1 { }
    public interface IDependency2 { }
    public class Dependency2 : IDependency2 { }
    public interface IBar { }
    public class Bar : IBar
    {
        public Bar(Dependency1 d1, IDependency2 d2) { }
    }
    public interface IBarFactory 
    {
        IBar Create();   
    }
    
    var kernel = new StandardKernel();
    kernel.Bind<IBarFactory>().ToFactory();
    kernel.Bind<IBar>().To<Bar>();
    kernel.Bind<Dependency1>().ToSelf();
    kernel.Bind<IDependency2>().To<Dependency2>();
    var factory = kernel.Get<IBarFactory>();
    var bar = factory.Create();
    bar.Should().BeOfType<Bar>();
