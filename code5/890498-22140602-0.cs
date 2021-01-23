    [DataContract]
    public class Response
    {        
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public List<error> Errors { get; set; }
        public override string ToString()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(this);
        }
    }
