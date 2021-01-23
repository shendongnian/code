    [DataContract]
    public class Params
    {
        [DataMember(Name = "params1")]
        public object Params1 { get; set; }
    
        [DataMember(Name = "params2")]
        public object Params2 { get; set; }
    
        [DataMember(Name = "params3")]
        public object Params3 { get; set; }
    }
    Params param = new Params()
    {
        Params1 = true,
        Params2 = "MyString",
        Params3 = new Object(),
    };
    var json = GetRequestString(param);
