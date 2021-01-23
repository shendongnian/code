    StringBuilder sbContent=new StringBuilder();
    byte data = new byte[1024];
    int numBytes;
    
    while ((numBytes = sock.Receive(data))>0)
    {
      sbContent.Append(Encoding.UTF8.GetString(data));
    }
    
    // use sbContent.ToString()
