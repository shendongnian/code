    public partial class CommentAttachment
    {
         //required for overriding get/set auto-property
         private byte[] _FileContents; 
         public int FileId { get; set; }
         public int CommentID { get; set; }
         public string FileName { get; set; }
         public int FileSize { get; set; }
         public byte[] FileContents 
         { 
              get
              {
                   return Timestamp != null ? null : _FileContents;
              } 
              set
              {
                   _FileContents = value;
              }
         }  // holds large data
         public virtual TicketComment TicketComment { get; set; }
         //Concurrency Token - triggered on create or update
         public byte[] Timestamp { get; set; }
     }
