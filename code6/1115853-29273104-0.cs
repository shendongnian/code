    public class Recipient 
    {
         public int RecipientId { get; set; }
         public virtual Icollection<Message> Messages { get; set; }
         // etc
    }
     public class Message 
     {
         public int MessageId { get; set; }
         public virtual Recipient Recipient { get; set; }
         // etc
    } 
