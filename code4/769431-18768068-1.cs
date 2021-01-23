    public interface ISerializableEntity 
    {
        Dictionary<string, object> ToDictionary();
    };
    
    public class CustomerEntity : ISerializableEntity
    {
        public string CustomerName { get; set; }
        public string CustomerPrivateData { get; set; }
        public object DoNotSerializeCustomerData { get; set; }
    
        Dictionary<string, object> ISerializableEntity.ToDictionary()
        {
            var result = new Dictionary<string, object>();
            result.Add("CustomerName", CustomerName);
    
            var encryptedPrivateData = // Encrypt the string data here
            result.Add("EncryptedCustomerPrivateData", encryptedPrivateData);
        }
    
        return result;
    }
