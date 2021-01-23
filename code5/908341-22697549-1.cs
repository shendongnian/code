            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddr, 13579);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            using (client)
            using (NetworkStream stream = client.GetStream())
            using (StreamReader rd = new StreamReader(stream))
            using (StreamWriter wr = new StreamWriter(stream))
            {
                string menuOption = rd.ReadLine();
                switch (menuOption)
                {
                    case "1":
                    case "one":
                        string passToClient = "Test Message!";
                        wr.WriteLine(passToClient);
                        break;
                }
                while (menuOption != "4") ;
            }
