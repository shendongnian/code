    public class LibraryClassThatNeedsConnectionString
    {
        private string connectionStrong;
    
        public LibraryClassThatNeedsConnectionString(string connectionString)
        {
            this.connectionStrong = connectionString;
        }
    
        public string ReadTheDatabase(int somePrimaryKeyIdToRead)
        {
            var result = string.Empty;
    
            // Read your database and set result
    
            return result;
        }
    }
