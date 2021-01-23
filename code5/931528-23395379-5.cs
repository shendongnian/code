        static void Main(string[] args)
        {
            Console.Write("Port: ");
            int port = int.Parse(Console.ReadLine());
            TcpListener server = new TcpListener(port);
            try
            {
                server.Start();
                TcpClient client = server.AcceptTcpClient();
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                StreamReader sr = new StreamReader(client.GetStream());
                Thread readThread = new Thread(() => readSocket(sr));
                readThread.Start();
                string message = "";
                while (message != "exit")
                {
                    message = Console.ReadLine();
                    sw.WriteLine(message);
                }
                client.Close();
                return;                
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
        static void readSocket(StreamReader sr)
        {
            try
            {
                string message = "";
                while ((message = sr.ReadLine()) != null)
                {
                    Console.WriteLine(message);
                }
            }
            catch (System.IO.IOException) { /*when we force close, this goes off, so ignore it*/ }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
