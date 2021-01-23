    // a class that implements ICommonServices interface
    public class CommonServices : ICommonServices
    {
        public CommonServices(IServiceA serviceA, IServiceB serviceB)
        {
            this.ServiceA = serviceA;
            this.ServiceB = serviceB;
        }
        public IServiceA ServiceA { get; private set; }
        public IServiceB ServiceB { get; private set; }
    }
