    public class Document
    {
        public string FullPath { get; set; } // Full path to file, null for unsaved
        public string FileName 
        {
           get { return Path.GetFileName(FullPath); }
        }
    }
