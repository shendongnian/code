    [DataContract]
    class MyResponseClass
    {
        [DataMember(Name = "response")]
        public Response Response { get; set; }
    }
    
    [DataContract]
    public class Response
    {
        [DataMember(Name = "records")]
        public IDictionary<string, Record> Records { get; set; }
    }
    
    [DataContract]
    public class Record
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
