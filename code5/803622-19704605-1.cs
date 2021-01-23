    [Serializable]
    public class Employees
    {
        private List<Worker> _Workers;
        [XmlArray]
        public List<Worker> Workers
        {
            get { return _Workers; }
            set { _Workers = value; }
        }
    }
    [Serializable]
    public class Worker
    {
        public Int32 ID { get; set; }
        public String FirstName { get; set; }
        // etc.
        public void SerializeToXML(string outputFolderLocation)
        {
            try
            {
                if (!outputFolderLocation.EndsWith('\\'))
                {
                    outputFolderLocation += "\\";
                }
                //Create our own namespaces for the output
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value
                ns.Add("", "");
                XmlSerializer serializer = new XmlSerializer(typeof(Worker));
                string outpath = outputFolderLocation + "FileName-" + DateTime.Now.ToBinary().ToString() + ".xml";
                XmlTextWriter textWriter = new XmlTextWriter(outpath, Encoding.GetEncoding("ISO-8859-1"));
                serializer.Serialize(textWriter, this, ns);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error serializing to XML", ex);
            }
        }
    }
