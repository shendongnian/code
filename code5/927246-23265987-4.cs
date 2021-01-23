    public interface IFoo
    {
    }
    public interface IFoo<T> : IFoo
    {
    }
    public abstract class BaseFoo<T> : IFoo<T>
    {
    }
    public class Bar : BaseFoo<Bar>
    {
    }
    public class Baz : BaseFoo<Baz>
    {
    }
    // main
    var c = new Castle.Windsor.WindsorContainer();
    c.Register(Classes.FromAssemblyInThisApplication()
                .BasedOn<IFoo>()
                .Configure(x => Console.WriteLine(x.Implementation.Name))
                .WithService.Select(new Type[] {typeof(IFoo)})
                .Configure(x => x.LifeStyle.Is(LifestyleType.Singleton)));
    var all = c.ResolveAll<IFoo>(); // 2 components found
