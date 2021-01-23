    public class ViewModel {
        IService _service;
        public ViewModel(IServiceFactory factory){
            _service = factory.Create();
        }
        public void SaveWarehouse(Warehouse aWarehouse) {
            _service.AddWarehouse(aWarehouse);
        }
    }
    public interface IServiceFactory {
        IService Create();
    }
    public class ProductionFactory : IServiceFactory { //Dependency injected
        public IService Create() {
            return new ProdService();
        }
    }
