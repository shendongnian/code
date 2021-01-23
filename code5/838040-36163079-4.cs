    [XmlRoot(Namespace = "http://foo")]
    public class IncidentEvent
    {
        [XmlAttribute("EventTypeText", Namespace = "http://bar")]
        public string EventTypeText { get; set; }
    }
