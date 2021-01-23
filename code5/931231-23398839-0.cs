    string allPendingCommands = "";
    string commandSeparator = ";";  // your command separator character here
    while(tcpClient.Connected)
    {
       if (!networkStream.DataAvailable)
            System.Threading.Thread.Sleep(100);
            // you can change it depending on the frequency of availability of data
    
       // read 256 bytes into you array 
       // convert the byte[] to string
       // add the newly read text to the text remaining from previous command execution.
       allPendingCommands += theReadBytes;
    
       while(allPendingCommands.Contains(commandSeparator))
       {
           // it may happen that the string at the moment contains incomplete
           // string, which can also not be decoded/decrypted. This loop will
           // stop and the next 256 bytes (as much available) will be read and
           // appended into allPendingCommands. When the command gets completed,
           // allPendingCommands will contain the separator character and the
           // command will be properly decoded and executed.
    
           int idx = allPendingCommands.IndexOf(commandSeparator);
           string command = allPendingCommands.SubString(0, idx);
           allPendingCommand = allPendingCommand.SubString(idx + 1);
    
           // convert those bytes back to string (after decrypting/decoding)
            command = Decrypt(command);
    
           // Process the Command (command); // do the needful in the function
       } 
    }
