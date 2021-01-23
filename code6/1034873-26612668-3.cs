    namespace WCFServices
    {
        [ServiceContract(Name = "IService")]
        [KnownTypeAttribute(typeof(DataItem))]
        public interface IService
        {
            [OperationContract]
            void InstantiateThirdParties(string name, IEnumerable<IDataItem> data, IEnumerable<string> modules, IEnumerable<string> states);
        }
    }
