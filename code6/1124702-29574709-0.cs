    class DDSocket
    {
        public event Action OnConnectionClosed;
        public void Raise()
        {
            if (OnConnectionClosed != null)
            {
                OnConnectionClosed();
            }
        }
    }
    class Player :DDSocket
    {
        // make new event look as the same base class
        public new event Action OnConnectionClosed;
        public Player(DDSocket socket)
        {
            socket.OnConnectionClosed += Socket_OnConnectionClosed;
        }
        private void Socket_OnConnectionClosed()
        {
           if (OnConnectionClosed != null)
            {
                OnConnectionClosed();
            }
        }
    }
    // test those 2 classes
    static void Main()
        {           
            DDSocket d = new DDSocket();
          
            Player pl = new Player(d);
              pl.OnConnectionClosed += () => MessageBox.Show("test");
            d.Raise();
        }
