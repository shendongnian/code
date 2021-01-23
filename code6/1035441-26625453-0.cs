    public class FileManager
    {
        private static readonly FileManager singleton = new FileManager();
    
        public static FileManager Singleton
        {
            get { return FileManager.singleton; }
        } 
    
    
        private FileManager()
        { 
            
        }
    
        public void FinishReading()
        { 
            
        }
    }
    
    public class File
    {
        public void FinishReading()
        {
            //
            FileManager.Singleton.FinishReading();
        }
    }
