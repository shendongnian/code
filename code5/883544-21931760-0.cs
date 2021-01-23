    public class EventResponseData
    {
        [XmlElement(ElementName = "event", Namespace = "somenamespace")]
        public EventData Event { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
    }
