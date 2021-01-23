    public class LabAssistant
    {
        static XmlSerializer listSerializer;
        static LabAssistant()
        {
            // This must be cached to prevent memory & resource leaks.
            // See http://msdn.microsoft.com/en-us/library/System.Xml.Serialization.XmlSerializer%28v=vs.110%29.aspx
            listSerializer = new XmlSerializer(typeof(List<Question>), new XmlRootAttribute("Questions"));
        }
        public List<Question> Questions { get; set; }
        public static bool TryDeserializeFromXml(XmlElement element, out string name, out LabAssistant assistant)
        {
            name = element.Name;
            var child = element.ChildNodes.OfType<XmlElement>().Where(el => el.Name == "Questions").FirstOrDefault();
            if (child != null)
            {
                var list = (List<Question>)child.GetXml().LoadFromXML<List<Question>>(listSerializer);
                if (list != null)
                {
                    assistant = new LabAssistant() { Questions = list };
                    return true;
                }
            }
            assistant = null;
            return false;
        }
    }
    public class NPCs
    {
        public NPCs()
        {
            this.LabAssistants = new Dictionary<string, LabAssistant>();
        }
        public static XmlSerializer CreateXmlSerializer()
        {
            // No need to cache this.
            var serializer = new XmlSerializer(typeof(NPCs));
            serializer.UnknownElement += new XmlElementEventHandler(NPCs.XmlSerializer_LoadLabAssistants);
            return serializer;
        }
        public Dictionary<string, LabAssistant> LabAssistants { get; set; }
        public static void XmlSerializer_LoadLabAssistants(object sender, XmlElementEventArgs e)
        {
            var obj = e.ObjectBeingDeserialized;
            var element = e.Element;
            if (obj is NPCs)
            {
                var npcs = (NPCs)obj;
                string name;
                LabAssistant assistant;
                if (LabAssistant.TryDeserializeFromXml(element, out name, out assistant))
                    npcs.LabAssistants[name] = assistant;
            }
        }
    }
