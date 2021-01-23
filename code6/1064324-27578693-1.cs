    while(true) 
          {
            Console.Write("Waiting for a connection... ");
    
            // Perform a blocking call to accept requests.
            // You could also user server.AcceptSocket() here.
            TcpClient client = server.AcceptTcpClient();            
            Console.WriteLine("Connected!");
    
            data = null;
    
            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
    
            int i;
    
            // Loop to receive all the data sent by the client.
            while((i = stream.Read(bytes, 0, bytes.Length))!=0) 
            {   
              // Translate data bytes to a ASCII string.
              data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
              Console.WriteLine("Received: {0}", data);
    
              // Process the data sent by the client.
              data = data.ToUpper();
    
              byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
    
              // Send back a response.
              stream.Write(msg, 0, msg.Length);
              Console.WriteLine("Sent: {0}", data);            
            }
    
            // Shutdown and end connection
            client.Close();
          }
