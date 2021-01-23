    public class SocketViewModel
    {
        public string Name { get; set; }
        public List<Socket> Sockets { get; set; }
        public SocketViewModel()
        {
            Sockets = new List<Socket>();
        }
    }
