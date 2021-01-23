    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    public class MyObject
    {
        [DataMember]
        public int MyProperty { get; set; }
    }
