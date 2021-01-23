    public class FileSignature
    {
        public int FileSize { get; set; }
        public DateTime ModifiedDate { get; set; } //We could not take CreatedDate because it will be changed once the file moved but, modified date only change when it modified by editor (ie. notepad)
        public String FileType { get; set; }
        public String OldFileName { get; set; } //this is not the part of the combination of signature. It is just to get the old file name which is moved from.
    }
