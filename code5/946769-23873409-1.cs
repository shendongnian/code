    StringBuilder myCompleteMessage = new StringBuilder();
    try {
        do{
            bytesRead = clientStream.Read(message, 0, message.Length);
	        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(message, 0, bytesRead );			 					
        } while(clientStream.DataAvailable);
    }
    ///catch and such....
    System.Diagnostics.Debug.WriteLine(myCompleteMessage);
