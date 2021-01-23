    public class IncidentEvent
    {
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        [XmlAttribute("EventTypeText", Namespace = "http://foo")]
        public string EventTypeText { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IncidentEvent xmlObj = new IncidentEvent()
            {
                EventDate = "2012.12.01",
                EventTime = "1:00:00",
                EventTypeText = "Beginining"
            };
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("ett", "http://foo");
            XmlSerializer serializer = new XmlSerializer(typeof(IncidentEvent));
            serializer.Serialize(Console.OpenStandardOutput(), xmlObj, ns);
            Console.WriteLine();
        }
    }
