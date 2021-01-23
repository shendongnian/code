    namespace MyNameSpace
    {
        public interface IMessage
        {
           // SendMyMessage is the function of this interface
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
