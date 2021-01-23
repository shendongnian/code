    public class FileCache
    {
        private readonly ConcurrentDictionary<string,string> fileContentsCache 
            = new ConcurrentDictionary<string, string>();
        public string ReadAllText(string filePath)
        {
            return fileContentsCache.GetOrAdd(filePath, File.ReadAllText);
        }
    }
