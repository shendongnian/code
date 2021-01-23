    public class LibraryClassThatNeedsConnectionString
    {
        private string connectionString;
    
        public LibraryClassThatNeedsConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }
    
        public string ReadTheDatabase(int somePrimaryKeyIdToRead)
        {
            var result = string.Empty;
    
            // Read your database and set result
    
            return result;
        }
    }
