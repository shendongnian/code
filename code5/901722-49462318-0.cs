    public class SessionConfig
    {
        // mylistbox
        public List<string> myItems = new List<string>();
        public void Serialize(SessionConfig details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SessionConfig));
            using (TextWriter writer = new StreamWriter(string.Format("{0}\\config.xml", Application.StartupPath)))
            {
                serializer.Serialize(writer, details);
            }
        }
    }
