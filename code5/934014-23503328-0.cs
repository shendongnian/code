    taskOpenEndpoint = Task.Factory.StartNew(() =>
        {
            UnicodeEncoding enc = new UnicodeEncoding(false, false, false);
            while (true)
            {
               serverStream = tcpClient.GetStream();
               byte []message = new byte[16384];
               int bytesRead = 0;
               try {
         // --------- first version may avoid blocking:
                   while( encoder.GetCharCount(message, 0, bytesRead) < 4096 
                      && bytesRead < message.Length )
                   {
                      if( serverStream.DataAvailable /* && !timed_out */ )
                          message[bytesRead++] = serverStream.ReadByte();
                      else
                          Thread.Sleep(10);  // Better to wait than sleep...
                   }
         // --------- second version will fully block:  
                   while( encoder.GetCharCount(message, 0, bytesRead) < 4096
                          && bytesRead < message.Length)
                       bytesRead += server.Read(
                            message, 
                            bytesRead, 
                            168384 - message.Length);
               catch (Exception ex)
               {
                   if(flag_chiusura == false)
                       MessageBox.Show(ex.Message);
                   return;
               }
               AddMessage(encoder.GetString(message, 0, bytesRead));
               Thread.Sleep(500);
            }
        });
