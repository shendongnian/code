    [DataContract]
    class IttResponse
    {
        [DataMember(Name = "response")]
        public int Response { get; protected set; }
        [DataMember(Name = "result")]
        public IttResult Result { get; protected set; }
    }
    [DataContract]
    public class IttResult
    {
        [DataMember(Name = "package")]
        public IttPackage Package { get; set; }
    }
    [DataContract]
    public class IttPackage
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
