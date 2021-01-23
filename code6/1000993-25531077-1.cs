    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect("127.0.0.1", 8000);
            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytes = server.Receive(buffer);
                Console.WriteLine(System.Text.Encoding.Default.GetString(buffer, 0, bytes));
            }
        }
    }
