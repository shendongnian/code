    [DataContract]
    public class MyObjectParent
    {
        [DataMember]
        public int ImportantValue { get; set; }
        [DataMember]
        public MyObjectChild Child { get; set; }
        [IgnoreDataMember]
        public AnotherClassThatIWantToIgnore IgnoreMe { get; set; }
    }
    [DataContract]
    public class MyObjectChild
    {
        [DataMember]
        public string ImportantValue { get; set; }   
    }
    public string ObjectAsJson<T>(T obj) where T : class
    {
        var serializer = new DataContractJsonSerializer(typeof(T));
        using (var stream = new MemoryStream())
        {
           serializer.WriteObject(stream, obj);
           return Encoding.Default.GetString(stream.ToArray());
        }
    }
