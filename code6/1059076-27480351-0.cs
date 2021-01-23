    [Serializable]
    public class AjaxMsg
    {
        [DataMember]
        public string MessageType { get; set; }
        [DataMember]
        public object MessageData { get; set; }
    }
    public class Data
    {
        public IList< AjaxMsg> list {get;set;}
    }
    var obj = JsonConvert<Data>(json);
