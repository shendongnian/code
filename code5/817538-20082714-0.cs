     public Form1()
     {
         client = new Client(e.Accepted,e.user,AppendText);
     }
    public class Client
    {
        private Action<string> _callback;
        public Client(string username, Action<string> callback)
        {
            _callback = callback;
        }
        private void Process()
        {
            .......
            _callback("Client " + this.username + " has completed uploading the file " + queue.Filename + ".");
        }
    }
