    using LightInject;
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.Register<Bar>();
            container.Register<Foo>();
            container.Register<Bar, Foo>((factory, bar) => new Foo(bar), "FooWithRuntimeArgument");            
            var instance = container.GetInstance<Foo>();            
            var instanceWithRuntimeArgument = container.GetInstance<Bar, Foo>(new Bar(), "FooWithRuntimeArgument");
        }
    }
    public class Foo
    {                
        public Foo(Bar bar) {}        
    }
    public class Bar {}
