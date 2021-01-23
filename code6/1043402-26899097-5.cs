    using System.ServiceModel;
    namespace ClassLibrary1
    {
        [ServiceContract] 
        public interface IWCFServiceLibrary1
        {
            [OperationContract]
            string GetData(string value);
        }
    }
