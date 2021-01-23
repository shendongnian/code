    public interface IFooFactory {   IFoo Create();   }
    public interface IFoo        {   void DoFoo();    }
    public class Foo : IFoo
    {
        public void DoFoo()
        {
            Console.WriteLine("I pity the foo");
        }
    }
    public class Bar
    {
        public IFooFactory MyFooFactory { get; set; }
        public void DoBar()
        {
            var foo = MyFooFactory.Create();
            foo.DoFoo();
        }
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<Bar>().ImplementedBy<Bar>().LifestyleTransient(),
                Component.For<IFoo>().ImplementedBy<Foo>().LifestyleTransient(),
                Component.For<IFooFactory>().AsFactory());
            container.AddFacility<TypedFactoryFacility>();
            var bar = container.Resolve<Bar>();
            bar.DoBar();
        }
    }
