    class Program
    {
            static void Main(string[] args)
            {
                String xmlPath = @"C:\Users\Desktop\example.xml";
                List<FolderPath> paths = new List<FolderPath>();
                paths.Add(new FolderPath { Path = "c:/temp" });
    
                XmlSerializer<List<FolderPath>> ser = new XmlSerializer<List<FolderPath>>();
                String xml = System.IO.File.ReadAllText(xmlPath);
                List<FolderPath> testDeserializeXml = ser.DeserializeXml(xml);
                var serializeToXmlString = ser.SerializeToXmlString(paths);
              
              
            }
    }
    
    public class FolderPath
    {
        public string Path { get; set; }
    }
