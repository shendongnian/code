     namespace MyNameSpace
     {
        public interface IMessage
        {
           // If your architecture need this method and this method belong to this interface then why not ?!
           SendMyMessage();
        }
        public class MyMessage : IMessage
        { 
           public void SendMyMessage()
            {
              //Do something here
            }
        }
    }
