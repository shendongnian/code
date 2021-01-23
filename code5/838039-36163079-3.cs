    [XmlRoot(Namespace = "http://foo")]
    public class IncidentEvent
    {
        [XmlAttribute("EventTypeText", Namespace = "http://foo")]
        public string EventTypeText { get; set; }
    }
