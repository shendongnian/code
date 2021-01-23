    public class Message
    {
       public int Id {get; set;}             // MessageId
       // use the 'virtual' keyword and/or add an ArticleId and/or use some Attributes.  
       public int ArticleId { get; set; }
       public virtual Article Article { get; set; }  // Owner
       public string body {get; set;}
    }
