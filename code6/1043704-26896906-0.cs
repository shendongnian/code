    public MyFileInfo 
    {
       private FileInfo _fileInfo;
      
       public FileAttributes Attributes { get { return _fileInfo.Attributes; }  set { _fileInfo.Attributes = value; } }
    
       // other file info methods
    
       public override ToString()
       {
          // your code
       }
    }
