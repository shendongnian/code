    class Server
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener list = new TcpListener(IPAddress.Any, 8080);
                list.Start();
                Console.WriteLine("The server is running at port 8080...");
                Console.WriteLine("The Local End point Is:" + list.LocalEndpoint);
                Socket s = list.AcceptSocket();
                Console.WriteLine("Connections Accepted from:" + s.RemoteEndPoint);
                byte[] b = new byte[100];
                int k;
                while ((k = s.Receive(b)) > 0)
                {
                    Console.WriteLine("Recived...");
                    Console.WriteLine(Encoding.ASCII.GetString(b, 0, k));
                    s.Send(Encoding.ASCII.GetBytes("The String Was Recived throw Server"));
                    Console.WriteLine("\n Sent Acknowlegment");
                }
                s.Shutdown(SocketShutdown.Both);
                s.Close();
                list.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
