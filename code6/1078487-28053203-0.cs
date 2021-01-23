    class CustomSocket
    {
        private Socket _socket;
        public CustomSocket(Socket socket)
        {
            _socket = socket;
        }
        public CustomSocket Accept()
        {
            return new CustomSocket(_socket.Accept());
        }
    }
