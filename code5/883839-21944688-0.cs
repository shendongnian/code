    public class ConfigurationFile
    {
        public String ConfigurationFilePath { get; set; }
        public String ConnectionString { get; set; }
        public String AnalyzeFilePath { get; set; }
    
        public ConfigurationFile(String xmlFilePath)
        {
            XDocument document = XDocument.Load(xmlFilePath);
            var root = document.Root;
    
            ConfigurationFilePath = (string)root.Element("ConfigurationFilePath");
            ConnectionString = (string)root.Element("ConnectionString");
            AnalyzeFilePath = (string)root.Element("AnalyzeFilePath");
        }
    }
