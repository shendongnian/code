    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 8000);
            var server = client.GetStream();
            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytes = server.Read(buffer, 0, 1024);
                Console.WriteLine(System.Text.Encoding.Default.GetString(buffer, 0, bytes));
            }
        }
    }
