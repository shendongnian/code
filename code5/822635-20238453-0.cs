    public partial class CommentAttachment
    {
        public int FileId { get; set; }
        public int CommentID { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
    
        public virtual TicketComment TicketComment { get; set; }
    }
    
    public class FileContent
    {
         FileContentId {get;set;}
         public int FileId { get; set; } // HERE IS THE FORGEIN KEY YOU HAVE TO UPDATE IT manually
         public byte[] FileContents { get; set; }  // holds large data
    }
