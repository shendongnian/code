    public class ExFileWatcher : FileSystemWatcher
    {
        public ExFileWatcher(string filePath)
            : base(filePath)
        {
        }
        public ExFileWatcher(string filePath, string filter)
            : base(filePath,filter)
        {
        }
        public object Tag
        {
            get;
            set;
        }
        
    }
