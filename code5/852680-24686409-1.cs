      while (true)
      {
      System.Console.WriteLine("The server is running at port 8001...");
      System.Console.WriteLine("Waiting for a connection.....");
      using (TcpClient client = _listener.AcceptTcpClient())
      {
            int incomingDataLength = client.ReceiveBufferSize;
            using (Stream ist = client.GetStream())
            {
                  //Stream ist = client.GetStream();
                  using (BufferedStream bst = new BufferedStream(ist))
                  {
                         //BufferedStream bst = new BufferedStream(ist);
                         int k = 0;
                         String line = ReadLine(bst);
                         System.Console.WriteLine(line);
                          while ((line = ReadLine(bst)) != null)
                          {
                                if (line == "") break;
                                System.Console.WriteLine(line);
                          }
                          
                          using (MemoryStream ms = new MemoryStream())
                          {
                                //MemoryStream ms = new MemoryStream();
                                int contentLen = 3429;
                                if (this.HttpHeaders.ContainsKey("Content-Length"))
                                {
                                      //content_len = Convert.ToInt32(this.HttpHeaders["Content-Length"]);
                                      byte[] buf = new byte[4096];
                                      int to_read = content_len;
                                      while (to_read > 0)
                                      {
                                             int numread = bst.Read(buf, 0, Math.Min(buf.Length, to_read));
                                             if (numread == 0)
                                             {
                                                   if (to_read == 0) break;
                                                  else throw new Exception("client disconnected during post");
                                             }
                                             to_read -= numread;
                                             ms.Write(buf, 0, numread);
                                       }
                                       ms.Seek(0, SeekOrigin.Begin);
                                 }
                           using (StreamReader sr = new StreamReader(ms))
                           {
                                 System.Console.WriteLine(sr.ReadToEnd());
                           }
                           //bst.Close();
                           client.Close();
                     } //end memorystream
                  } //end bufferedsteam
              } //end stream
          } //end tcpClient
      } //end while
                                    
