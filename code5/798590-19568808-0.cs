    [DataContract]
    public class object
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
 
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "values")]
        public values values{ get; set; }
        public object()
        {
            values = new values();
        }
     }
