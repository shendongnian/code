    [XmlRoot(Namespace = "http://foo")]
    public class IncidentEvent
    {
        [XmlAttribute("EventTypeText", Namespace = "http://foo", Form = XmlSchemaForm.Qualified)]
        public string EventTypeText { get; set; }
    }
