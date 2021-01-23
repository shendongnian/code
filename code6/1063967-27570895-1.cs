    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("192.168.1.7", 8080);
                Console.WriteLine("Connected");
                Console.Write("Enter the string to be Sent : ");
                String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();
                byte[] ba = Encoding.ASCII.GetBytes(str);
                Console.WriteLine("Sending.....");
                stm.Write(ba, 0, ba.Length);
                tcpclnt.Client.Shutdown(SocketShutdown.Send);
                byte[] bb = new byte[100];
                int k;
                while ((k = stm.Read(bb, 0, 100)) > 0)
                {
                    Console.WriteLine(Encoding.ASCII.GetString(bb, 0, k));
                }
                Console.ReadLine();
                tcpclnt.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
        }
    }
