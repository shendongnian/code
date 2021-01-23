    public class File
    {
        public Uri Url { get; set; }
        public string Name { get; set; }
        public bool? ClientReq { get; set; }
    }
    
    public class Version
    {
        public IList<File> Files { get; set; }
    }
    
    public class MyMessage
    {
        public Version Version { get; set; }
    }
