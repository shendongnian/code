    using System.Runtime.Serialization;
    using System.ServiceModel;
    
    namespace WcfService1
    {
        
        [ServiceContract]
        
        public interface IService1
        {
    
            [OperationContract]
            [ServiceKnownType(typeof(SubItem))] // try to comment this and uncomment GetDataUsingDataContract 
             Item GetData(int value);
    
            //[OperationContract] //here try to comment/uncomment and see if the subitem was deserialized at client side the operation on server side will not be executed 
            //Item GetDataUsingDataContract(SubItem item);
    
            //// TODO: Add your service operations here
        }
    
    
        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        [DataContract]
        
        public class Item
        {
            bool boolValue = true;
            string stringValue = "Hello ";
    
            [DataMember]
            public bool BoolValue
            {
                get { return boolValue; }
                set { boolValue = value; }
            }
    
            [DataMember]
            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
        }
        //[DataContract]
        public class SubItem:Item
        {
            private string _subItemVersion;
            //[DataMember]
            public string SubItemToStringValueVersion { get { return _subItemVersion; } set { _subItemVersion = value; } }
        }
    }
