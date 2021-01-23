    public class Container
    {
        // static holder for instance, need to use lambda to construct since constructor private
        private static readonly Lazy<IWindsorContainer> instance = new Lazy<IWindsorContainer>(() =>
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            return container;
        });
        // private to prevent direct instantiation.
        private Container()
        {
        }
        // accessor for instance
        public static IWindsorContainer Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
