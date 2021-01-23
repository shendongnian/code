    public class FileManager
    {
        public FileManager()
        { 
            
        }
    
        public File CreateFile()
        {
            File f = new File(this.FinishReading);
    
            return f;
        }
    
        public void FinishReading()
        { 
            
        }
    }
    
    public class File
    {
        public delegate void FinishReadingDelegate();
        private FinishReadingDelegate del;
    
        public File(FinishReadingDelegate Del)
        {
            del = Del;
        }
    
    
        public void FinishReading()
        {
            //
            del.Invoke();
        }
    }
