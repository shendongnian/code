    private static void ReceiveCallback(IAsyncResult ar) 
     { 
         StateObject state = (StateObject)ar.AsyncState; 
         Socket clientSocket = state.WorkSocket; 
         BinaryWriter writer; 
     
     
         int bytesRead = clientSocket.EndReceive(ar); 
         if (bytesRead > 0) 
         { 
             //If the file doesn't exist, create a file with the filename got from server. If the file exists, append to the file. 
             if (!File.Exists(fileSavePath)) 
             { 
                 writer = new BinaryWriter(File.Open(fileSavePath, FileMode.Create)); 
             } 
             else 
             { 
                 writer = new BinaryWriter(File.Open(fileSavePath, FileMode.Append)); 
             } 
     
     
             writer.Write(state.Buffer, 0, bytesRead); 
             writer.Flush(); 
             writer.Close(); 
     
     
             // Notify the progressBar to change the position. 
             Client.BeginInvoke(new ProgressChangeHandler(Client.ProgressChanged)); 
     
     
             // Recursively receive the rest file. 
             try 
             { 
                 clientSocket.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state); 
             } 
             catch 
             { 
                 if (!clientSocket.Connected) 
                 { 
                     MessageBox.Show(Properties.Resources.DisconnectMsg); 
                 } 
             } 
         } 
         else 
         { 
             // Signal if all the file received. 
             receiveDone.Set(); 
         } 
     }
 
