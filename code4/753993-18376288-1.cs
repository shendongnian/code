    public interface IService : IDisposable {
    }
    public class DefaultService : IService {
        public void Dispose() {
        }
    }
    public interface IServiceProvider {
        IService GetService();
    }
    public class DefaultServiceProvider : IServiceProvider {
        public IService GetService() {
            return new DefaultService();
        }
    }
    public class Consumer {
        private readonly IServiceProvider serviceProvider;
        public Consumer() : this (new DefaultServiceProvider()){
        }
		
        internal Consumer(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }
        public void DoIt() {
            using (var service = serviceProvider.GetService()) {
              // do stuff								
            }
        }
    }
