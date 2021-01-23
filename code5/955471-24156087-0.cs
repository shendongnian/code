    public class Chat : XSocketController
    {
        public void ChatMessage(string text)
        {
            this.InvokeToAll(text,"chatmessage");
        }
    } 
