    [DataContract]
    public class MyObject
    {
        [DataMember(Name = "extra_data")]
        public Dictionary<string, string> MyDictionary { get; set; } 
    
    }
