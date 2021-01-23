    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IFoo, Foo1>("Foo1");
            container.RegisterType<IFoo, Foo2>("Foo2");
 
            container.RegisterType<Client1>(new InjectionConstructor(new ResolvedParameter<IFoo>("Foo1")));
            container.RegisterType<Client2>(new InjectionConstructor(new ResolvedParameter<IFoo>("Foo2")));
 
            Client1 client1 = container.Resolve<Client1>();
            Client2 client2 = container.Resolve<Client2>();
        }
    }
 
    public interface IFoo
    {
 
    }
 
    public class Foo1 :IFoo
    {
 
    }
 
    public class Foo2 : IFoo
    {
 
    }
 
    public class Client1
    {
        public Client1(IFoo foo)
        {
 
        }
    }
 
    public class Client2
    {
        public Client2(IFoo foo)
        {
 
        }
    }
