    public interface IFoo { }
    public interface IBar { }
    public class FooBar : IFoo, IBar
    {
    }
    //registrations: (transient)
    container.Register<IFoo, FooBar>();
    container.Register<IBar, FooBar>();
