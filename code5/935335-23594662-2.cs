    [XmlRoot("Log")]
    [Serializable]
    public class Log
    {
        public Log() { }
    
        [XmlElement("InterfaceID")]
        public string InterfaceID { get; set; }
        [XmlElement("MESKey")]
        public string MESKey { get; set; }
        [XmlElement("MsgStatusCode")]
        public string MsgStatusCode { get; set; }
        [XmlElement("MsgClass")]
        public string MsgClass { get; set; }
        [XmlElement("MsgNumber")]
        public string MsgNumber { get; set; }
        [XmlElement("MsgDescription")]
        public string MsgDescription { get; set; }
    
        [XmlElement("PrOrNumber")]
        public string PrOrNumberRaw
        {
            get { return this.PrOrNumber.ToString(); }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.PrOrNumber = int.Parse(value);
                }
                else
                {
                    this.PrOrNumber = null;
                }
            }
        }
    
        [XmlIgnore]
        public int? PrOrNumber { get; set; }
    }
