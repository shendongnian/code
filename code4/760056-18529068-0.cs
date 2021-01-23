    [Serializable]
    [XmlRoot(ElementName="error")]
    public class Error
    {
        [XmlElement(
            ElementName = "bad-request",
            Type = typeof(BadRequest),
            Namespace = "blah:ns")]
        [XmlElement(
            ElementName = "forbidden",
            Type = typeof(Forbidden),
            Namespace = "blah:ns")]
        public ErrorDetails ErrorDetails { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public int Code { get; set; }
    }
    [Serializable]
    public abstract class ErrorDetails
    {
    }
    [Serializable]
    public class BadRequest : ErrorDetails
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
    [Serializable]
    public class Forbidden : ErrorDetails
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
