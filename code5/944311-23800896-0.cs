    TcpClient tcpClient = new TcpClient();
          try
               {
                    tcpClient.Connect("152.26.53.39", 2775);
                    Console.WriteLine("Port 2775 Open");
                }
          catch (Exception){
    
                   Console.WriteLine("Port 2775 Closed");
           }
