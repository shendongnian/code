    content = state.sb.ToString();
    if (content.IndexOf("<EOF>") > -1) {
         // All the data has been read from the 
         // client. Display it on the console.
         Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                     content.Length, content );
         // Echo the data back to the client.
         Send(handler, content);
    
         { // NEW 
             // Reset your state (persist any data that was from the next message?)      
   
             // Wait for the next message.
             handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, 
             new AsyncCallback(ReadCallback), state);
         }
     } else {
          // Not all data received. Get more.
          handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, 
          new AsyncCallback(ReadCallback), state);
    }
