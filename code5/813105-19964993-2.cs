    class XMLHandler : IFileHandler {
       
       private OpenFile xmlFileReader;
       private FileInfo fileSpec;
    
       // implementation of interface
       public OpenFile FileHandler {
          get { return xmlFileReader; }
       }
    
       public XMLHandler(FileInfo XmlFileSpec){
          fileSpec = XmlFileSpec;
          xmlFileReader = MyXmlFileReader;  // references the private method in this class
       }
    
       private Stream MyXmlFileReader(FileInfo XmlFileSpec) {
          // implementation specific to this class
       }
    
    }
    
    interface IFileHandler {
    
       OpenFile FileHandler { get; }
    
    }
