    public class Snapchat : SocialNetwork
    {
        private string _lastMessage;
     
        protected override void DoPost(string comment, byte[] image)
        {
            //Logic to do a snapchat post
            _lastMessage = comment;
            ProcessLastMessage();
            History.Clear();
        }
         
        private void ProcessLastMessage()
        {
            //Some logic here.
        }
    }
