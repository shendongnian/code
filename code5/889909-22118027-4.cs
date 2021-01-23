     string debugFileName = "C:\\myLog.txt";  //declare this as class variable
     public byte sendMessage(string strMsgId, string strMessage)
        {
        StringBuilder strLines=new StringBuilder();
        byte result = 1;
        try
        {
            if (strMsgId == "02") 
            {                
                // Build timestamp string
                var currentDateTime = DateTime.Now;
                string timeStampString = currentDateTime.ToString("yyyy-MM-dd hhmmssfff");
               
                // Write to the file:
                strLines.Append(DateTime.Now);
                strLines.Append("Time = {0}", currentDateTime.ToString("yyyy-MM-dd hh:mm:ss:fff tt"));
                strLines.Append("{0}{1}{2}", "Inbound Message:", Environment.NewLine, strMessage.Substring(1016, 26));                
                result = 0;
                File.WriteAllText(debugFileName , str.ToString());
              }
            }
        }
        catch
        {
            //Failed
            result = 1;
        }
        return result;  
       }
