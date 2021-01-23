    public static class IsolatedStorageFileExtensions
    {
        public static void WriteAllText(this IsolatedStorageFile storage, string fileName, string content)
        {
            using (var stream = storage.CreateFile(fileName))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(content);
                }
            }
        }
    
        public static string ReadAllText(this IsolatedStorageFile storage, string fileName)
        {
            using (var stream = storage.OpenFile(fileName, FileMode.Open))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
