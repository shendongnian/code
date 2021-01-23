     class Program
    {        
        static void Main(string[] args)
        {
            List<KeyValuePair<string,List<ForwardBarrelRecord>>>  lexicon   = new List<KeyValuePair<string,List<ForwardBarrelRecord>>>();  
            ForwardBarrelRecord FBR = new ForwardBarrelRecord();  
            FBR.DocId ="12"; 
            FBR.hits= 14;  
            FBR.hitLocation = new List<int>(){12,13,114};
            var lst = new List<ForwardBarrelRecord>() { FBR, FBR };
            KeyValuePair<string,List<ForwardBarrelRecord>> t= new KeyValuePair<string,List<ForwardBarrelRecord>>("Test",lst);
            lexicon.Add(t);            
            XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair<string, List<ForwardBarrelRecord>>>));
            string  fileName= @"D:\test\test.xml";
            Stream stream = new FileStream(fileName,FileMode.Create);
            serializer.Serialize(stream,lexicon);
            stream.Close();            
        }     
    }
    
    public struct ForwardBarrelRecord
    {
        [XmlElement]
        public string DocId;
        [XmlElement]
        public int hits { get; set; }
        [XmlElement]
        public List<int> hitLocation;
    }
