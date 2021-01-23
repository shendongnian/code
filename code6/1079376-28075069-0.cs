    try
    {
        using (FileStream SourceFile = File.OpenRead(TheFile))
        using (StreamReader sr = new StreamReader(SourceFile))
        {
            char[] block = new char[3];
            byte[] header = new byte[6];
            SourceFile.Read(header, 0, 6);
            SourceFile.Seek(0, 0);
            Encoding encoding = (header[1] == 0 && header[3] == 0 && header[5] == 0) ? Encoding.Unicode : Encoding.UTF8;
            sr.ReadBlock(block, 0, 3);
            String sBlock = new String(block);
            SourceFile.Seek(0, 0);
            if (sBlock=="ABC")
            {
                MyFunction(SourceFile);
            }
            // And do anything else you want with SourceFile & sr here
        }
    }
    catch (Exception ex)
    {
        String Error = "Error Accessing: " + TheFile  + " System Message: " + ex.Message;
        EventLog.LogEvent(dtmLogging.LogEventType.Error, Error);
        MessageError(Error, "MyFunction()");
    }
