     using (var inboundMessageLog = new StreamWriter(debugFileName, false, System.Text.Encoding.Default)) {  
        // Write to the file:  
        inboundMessageLog.WriteLine(DateTime.Now);  
        inboundMessageLog.WriteLine("Time = {0}", currentDateTime.ToString("yyyy-MM-dd hh:mm:ss:fff tt"));  
        inboundMessageLog.WriteLine("{0}{1}{2}", "Inbound Message:", Environment.NewLine, strMessage.Substring(1016, 26));  
     }  
