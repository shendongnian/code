    public class SocketEventArgs : EventArgs
    {
        public Socket Socket { get; private set; }
        public SocketEventArgs(Socket socket)
        {
            Socket = socket;
        }
    }
