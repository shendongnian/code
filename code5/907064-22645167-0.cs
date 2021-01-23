    using System.ServiceModel;
    using System.Threading;
    
    namespace WcfService
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string GetTest();
        }
    
        public class Service1 : IService
        {
            public string GetTest()
            {
                Thread.Sleep(2000);
                return "foo";
            }
        }
    }
