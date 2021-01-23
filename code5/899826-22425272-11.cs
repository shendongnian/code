    // Defined in an application layer
    public interface IMyFactory
    {
        IMyService CreateService();
    }
    // Defined inside the Composition Root
    public class MyFactory : IMyFactory
    {
        private readonly Container container;
        public MyFactory(Containter container)
        {
            this.container = container;
        }
        public IMyService CreateService(ServiceType type)
        {
            return type == ServiceType.A
                ? this.container.GetInstance<MyServiceA>()
                : this.container.GetInstance<MyServiceB>();
        }
    }
