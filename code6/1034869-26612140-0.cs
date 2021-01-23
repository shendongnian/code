    namespace WCFServices
    {
        [ServiceContract(Name = "IService")]
        [ServiceKnownTypeAttribute(typeof(DataItem))]
        public interface IService
        {
            [OperationContract]
            void InstantiateThirdParties(string name, IEnumerable<IDataItem> data, IEnumerable<string> modules, IEnumerable<string> states);
        }
    }
    namespace DataObjects
    {
        [DataContract]
        [KnownType(typeof(IDataItem))]
        public class DataItem : IDataItem
        {
            ...
        }
    }
