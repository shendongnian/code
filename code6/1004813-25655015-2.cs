    [DataContract(Namespace = "http://TestNameSpace")]
    public class Config
    {
      public Config()
      {
        SerializableDictionary = new SerializableDictionary<int, string>();
      }
    
      [DataMember]
      public SerializableDictionary<int, string> SerializableDictionary { get; set; }
    }
    
    [CollectionDataContract(Name = "SerializableDictionary", ItemName = "DictionaryItem", KeyName = "Key", ValueName = "Value", Namespace = "http://TestNameSpace")]
    public sealed class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
    
    }
