    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Foo>().AsSelf();
            builder.RegisterType<Bar1>().As<IBar>();
            IContainer container = builder.Build();
            Foo foo = container.Resolve<Foo>();
            foo.Do(); // ==> DependencyResolutionExtension 
            // update the container with the Pouet type
            builder = new ContainerBuilder();
            builder.RegisterType<Pouet>().AsSelf();
            builder.Update(container);
            foo.Do(); // OK
            // update the container with another IBar
            builder = new ContainerBuilder();
            builder.RegisterType<Bar2>().As<IBar>();
            builder.Update(container);
            foo.Do(); // OK 
        }
    }
    public class Foo
    {
        public Foo(Func<IBar> barFactory)
        {
            this._barFactory = barFactory;
        }
        private readonly Func<IBar> _barFactory;
        public void Do()
        {
            IBar bar = this._barFactory();
        }
    }
    public interface IBar { }
    public class Bar1 : IBar
    {
        public Bar1(Pouet p) { }
    }
    public class Bar2 : IBar
    {
    }
    public class Pouet { }
