    [DataContract]
    public class Response
    {
        [DataMember(Order = 0)]
        public string Status { get; set; }        
        
        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public List<Error> Errors { get; set; }
    }
