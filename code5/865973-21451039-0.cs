    namespace V1
    {
        [ServiceContract]
        public interface IService { ... }
        public class MyService : IService { ... }
    }
    
    namespace V2
    {
        [ServiceContract]
        public interface INewService { ... }
        public class MyNewService : V1.MyService, INewService { ... }
    }
