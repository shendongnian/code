    class Program
    {
        static void Main(string[] args)
        {
            ParCard pc = new ParCard();
            pc.ExtrFreq = "Daily";
            pc.LastDay = "20140101";
            pc.FolderPath = @"c:\temp";
            pc.Files = new List<EFile>() { new EFile() { FileName = "file1.txt" }, new EFile { FileName = "file2.txt" } };
            pc.FTPAddress = "10.1.1.100";
            pc.FTPPath = "Home";
            pc.FTPUser = "User";
            pc.FTPPass = "Pass";
            Serialize(pc);
        }
        static public void Serialize(ParCard pc)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ParCard));
            using (TextWriter writer = new StreamWriter(@"Teste.xml"))
            {
                serializer.Serialize(writer, pc);
            }
        }
    }
    public class ParCard
    {
        public string ExtrFreq { get; set; }
        public string LastDay { get; set; }
        public string FolderPath { get; set; } 
        
        [XmlIgnore]
        public List<EFile> Files { get; set; }
        [XmlArray("Files"), XmlArrayItem(typeof(string), ElementName = "FileName")]
        public List<string> FilesAsString { get; set; }
        public string FTPAddress { get; set; }
        public string FTPPath { get; set; }
        public string FTPUser { get; set; }
        public string FTPPass { get; set; }
        public bool ShouldSerializeFilesAsString()
        {
            List<string> fileNames = new List<string>();
            foreach (var eFile in Files)
            {
                fileNames.Add(eFile.FileName);
            }
            FilesAsString = fileNames;
            return true;
        }
    }
    
    public class EFile
    {
        public string FileName { get; set; }
    }
