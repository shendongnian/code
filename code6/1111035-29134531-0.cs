    {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();
              
                
              
                TcpClient sslmail = new TcpClient();
                SslStream sslStream;
                
                    sslmail.Connect(server, sslport);
                    sslStream = new SslStream(sslmail.GetStream());
    
                    sslStream.AuthenticateAsClient(server);
                int buffersize=1024;    
                byte[] buffer = new byte[buffersize];
           
    
    
    
                    int bytes=0;
    
                    while((sslmail.Connected) && (tcpClient.Connected))
                    { 
             
                try
                {
    
                    Array.Clear(buffer, 0, buffer.Length);
    
    
                    try
                    {
                        sslStream.ReadTimeout = 100;
                        bytes = sslStream.Read(buffer, 0, buffer.Length);
    
    
                        clientStream.Write(buffer, 0, bytes);
                        clientStream.Flush();
    
    
                    }
                    catch (Exception err)
                    {
                        //timeout, server is waiting for client     
                    }
                     
                    
                    Array.Clear(buffer, 0, buffer.Length);
    
    
    
                     try
                     {
                         clientStream.ReadTimeout = 100;
                         bytes = clientStream.Read(buffer, 0, buffer.Length);
    
    
                        
                         sslStream.Write(buffer, 0, bytes);
                         sslStream.Flush();
                     }
                     catch (Exception err)
                     {
                     //timeout, client is waiting for Server
                     }
    }
                catch (Exception err)
                {
                    sslmail.Close();
                    tcpClient.Close();
                    MessageBox.Show(err.Message);
                }
                  
    
                        /////////////////////////////////////
                    }
    
                    sslmail.Close();
                tcpClient.Close();
            }
        }
