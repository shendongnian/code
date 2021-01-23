    namespace WindsorTest
    {
        public interface ISingleton  {}
    
        public class Singleton : ISingleton
        {
            public static int instance = 0;
            public Singleton() { Console.WriteLine("I live anew as instance {0}", instance++); }
        }
        
        internal class Program
        {
            private static void Main(string[] args)
            {
                TheCircleOfLife(false);
                TheCircleOfLife(true);
    
                Console.ReadLine();
            }
    
            private static void TheCircleOfLife(bool disposeBetweenReleases)
            {
                Console.WriteLine("I {0}dispose between resolves", disposeBetweenReleases ? "" : "don't ");
                var container = new WindsorContainer();
                container.Register(Component.For<ISingleton>().ImplementedBy<Singleton>().LifestyleSingleton());
                ISingleton singleton = container.Resolve<ISingleton>();
                container.Release(singleton);
                if (disposeBetweenReleases) container.Dispose();
                singleton = container.Resolve<ISingleton>();
                container.Release(singleton);
            }
        } 
    }
