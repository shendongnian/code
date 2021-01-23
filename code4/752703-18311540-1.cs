    [Serializable]
    public class CSVFile
    {
        [XmlElement("csvstrings")]
        public List<string> csvstrings { get; set; }
        
        public CSVFile()
        {
    
        }
    }
    
    [Serializable, XmlRoot("Configuration"), XmlType("Configuration")]
    public class Configuration
    {
        public Configuration()
        {
            
        }
    
        [XmlElement("CSVFile")]
        public CSVFile csvs { get; set; }
    }
    
    public class Mytutorial
    {
        string configFilePath = "above xml file path"
    
        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
        FileStream xmlFile = new FileStream(configFilePath, FileMode.Open);
        Configuration con = (Configuration)serializer.Deserialize(xmlFile);
    }
