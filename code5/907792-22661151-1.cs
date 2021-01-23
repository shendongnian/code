    [DataContract]
    [KnownType(typeof(Foo))]
    [KnownType(typeof(Bar))]
    public class Data {}
    
    [DataContract]
    public class NetworkMessage 
    {
        [DataMember]
    	public Data MyData { get; set; }
    }
    
    [DataContract]
    public class Foo : Data
    {
    	[DataMember]
    	public int SomeId { get; set; }
    }
    
    [DataContract]
    public class Bar : Data
    {
        [DataMember]
    	public string FirstName { get; set; }
    }
