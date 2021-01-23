    public class NewMessageArgs : EventArgs
    {
        public string Message { get; private set; }
        public NewMessageArgs(string message)
        {
            Message = message;
        }
    }
    public class ActiveXComponent
    {
        public event EventHandler<NewMessageArgs> OnMessage;
        public void StartThread()
        {
            while (true)
            {
                //do stuff
                //raise "message received" event
                if (OnMessage != null)
                    OnMessage(this, new NewMessageArgs("hi"));
            }
        }
    }
