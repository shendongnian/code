    public class UserImage
    {
        public string Description { get; set; } 
        [NotMapped]
        public LocalFile File { get; set; } 
    }
    
    // not EF entity
    public class LocalFile
    {
        private readonly string _filePath;
        public LocalFile(string filePath)
        {
            _filePath=filePath;
        }    
        public string Name { get; set; } 
        public string LocalPath { // aggregate Name and filePath } 
        public string Url { // should return LocalPath mapped to Url } If i where you, i would write helper for this
    }
