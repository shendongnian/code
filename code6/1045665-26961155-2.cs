    public class NameValuePair
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
        public override string ToString()
        {
            return string.Format("Name={0}, Value=\"{1}\"", Name, Value);
        }
    }
    [Serializable]
    [XmlRoot("Response")]
    public class ReportingResponse
    {
        [XmlElement(ElementName="Value")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public NameValuePair[] XmlNameValuePairs
        {
            get
            {
                return NameValuePairExtensions.GetNamedValues(this).ToArray();
            }
            set
            {
                NameValuePairExtensions.SetNamedValues(this, value);
            }
        }
        [XmlIgnore]
        public string ID { get; set; }
        [XmlIgnore]
        public string User { get; set; }
        [XmlIgnore]
        public string Description { get; set; }
    }
