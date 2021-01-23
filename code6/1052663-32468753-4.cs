    public class Snapchat : ISocialNetwork
    {
        private string _lastMessage;
     
        public void Post(string message, byte[] image)
        {
            //Logic to do a snapchat post
            _lastMessage = message;
            ProcessLastMessage();
        }
     
        private void ProcessLastMessage()
        {
            //Some logic here.
        }
    }
