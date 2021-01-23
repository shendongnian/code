    // Definition
    public interface IMyServiceFactory {
        IMyService CreateNew();
    }
    
    // Implementation
    sealed class ServiceFactory : IMyServiceFactory {
        public IMyService CreateNew() {
            return new MyServiceImpl();
        }
    }
    
    // Registration
    container.RegisterSingle<IMyServiceFactory, ServiceFactory>();
    
    // Usage
    public class MyService {
        private readonly IMyServiceFactory factory;
    
        public MyService(IMyServiceFactory factory) {
            this.factory = factory;
        }
    
        public void SomeOperation() {
            using (var service1 = this.factory.CreateNew()) {
                // use service 1
            }
    
            using (var service2 = this.factory.CreateNew()) {
                // use service 2
            }
        }
    }
