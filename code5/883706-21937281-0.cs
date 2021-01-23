    public class TempFolder : IDisposable
    {
        public string RootPath { get; private set; }
        
        public TempFolder()
        {
            RootPath = Path.GetTempPath();
        }
    
        public void Dispose()
        {
            Directory.Delete(RootPath, true);
        }
    }
