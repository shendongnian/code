    public class ParCard
    {
        public string ExtrFreq { get; set; }
        public string LastDay { get; set; }
        public string FolderPath { get; set; }
        public EFile Files { get; set; }
        public string FTPAddress { get; set; }
        public string FTPPath { get; set; }
        public string FTPUser { get; set; }
        public string FTPPass { get; set; }
    }
    
    public class EFile
    {
        [XmlElement("FileName")]
        public List<string> FileName { get; set; }
    }
