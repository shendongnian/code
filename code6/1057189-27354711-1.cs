            string strTemp = "Hello from server";
            try
            {
                IPAddress IP = IPAddress.Parse("127.0.0.1");
                TcpListener Listener = new TcpListener(IP, 8001);
                Listener.Start();
                Socket s = Listener.AcceptSocket();
                byte[] b = new byte[100];
                int k = s.Receive(b);
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(b[i]));
                }
                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string:" + strTemp + " was recieved by the server."));
                s.Close();
                Listener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            Console.ReadKey();
