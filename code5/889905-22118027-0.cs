     string debugFileName = "C:\\myLog.txt";//declare this as class variable
     public byte sendMessage(string strMsgId, string strMessage)
        {
        byte result = 1;
        try
        {
            if (strMsgId == "02") 
            {                
                // Build timestamp string
                var currentDateTime = DateTime.Now;
                string timeStampString = currentDateTime.ToString("yyyy-MM-dd hhmmssfff");
                var inboundMessageLog = new StreamWriter(debugFileName, false, System.Text.Encoding.Default);
                // Write to the file:
                inboundMessageLog.WriteLine(DateTime.Now);
                inboundMessageLog.WriteLine("Time = {0}", currentDateTime.ToString("yyyy-MM-dd hh:mm:ss:fff tt"));
                inboundMessageLog.WriteLine("{0}{1}{2}", "Inbound Message:", Environment.NewLine, strMessage.Substring(1016, 26));
                inboundMessageLog.Close();
                // -------------------------------------------------------------------------------------------
                result = 0;
            }
        }
        catch
        {
            //Failed
            result = 1;
        }
        return result;  
       }
