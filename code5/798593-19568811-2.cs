    [DataContract]
    //I've renamed it to stop it hurting my eyes.
    public class myClass
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
    
        [DataMember(Name = "message")]
        public string Message { get; set; }
    
        [DataMember(Name = "values")]
        public values values{ get; set; }
    }
