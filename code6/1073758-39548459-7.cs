    public class ClassThatNeedsToReadDatabaseUsingLibrary
    {
        private DatabaseSettings dbSettings;
        private LibraryClassThatNeedsConnectionString libraryClassThatNeedsConnectionString;
    
        public ClassThatNeedsToReadDatabaseUsingLibrary(IOptions<DatabaseSettings> dbOptions)
        {
            this.dbSettings = dbOptions.Value;
            this.libraryClassThatNeedsConnectionString = new LibraryClassThatNeedsConnectionString(this.dbSettings.ConnectionString);
        }
    
        public string ReadDatabaseUsingClassLibrary(int somePrimaryKeyIdToRead)
        {
            return this.libraryClassThatNeedsConnectionString.ReadTheDatabase(somePrimaryKeyIdToRead);
        }
    }
