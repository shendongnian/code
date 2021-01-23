    class ChatCallBack 
    {
        public event EventHandler<string> UserJoinedTheConversation;
        public void NotifyUserJoinedTheConversation(string username)
        {
            var evt = UserJoinedTheConversation;
            if (evt != null)
                evt(this, username);
        }
        
        //other code
    }
