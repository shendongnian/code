    public class CSVFileFinder
    {
        private readonly IOWrapper ioWrapper;
        private readonly string folderPath;
        public CSVFileFinder(string folderPath)
            : this(new IOWrapper(), folderPath)
        {  
        }
        public CSVFileFinder(IOWrapper ioWrapper, string folderPath)
        {
            this.ioWrapper = ioWrapper;
            this.folderPath = folderPath;
        }
        public IEnumerable<string> FetchFiles()
        {
            return this.ioWrapper.GetFiles(folderPath, "*.csv", SearchOption.AllDirectories);
        }
    }
