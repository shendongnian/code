    public class BatchFile
    {
        [XmlIgnore]
        public List<string> FileObject { get; set; }
    
        public List<string> File1 
        { 
            get {return FileObject[0];} 
            set {FileObject[0] = value; }
        }
    
        public List<string> File2 { get; set; }
        { 
            get {return FileObject[1];} 
            set {FileObject[1] = value; }
        }
    
        public List<string> File3 { get; set; }
        { 
            get {return FileObject[2];} 
            set {FileObject[2] = value; }
        }
    
    }
