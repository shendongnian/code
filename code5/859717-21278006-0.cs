    Boolean GetData(Stream fStream)
    {
        try 
        {	        
        // Read the stream into a byte array
        
        Byte[] data  = new Byte[32767];
        using (MemoryStream ms = new MemoryStream())
        {
                while(true)
                {
                        Int32 read = stream.Read(data, 0, data.Length);
                        if(read <= 0)
                            return ms.ToArray();
                        ms.Write(data, 0, read);
                }
        }
        
        // Copy to a string for header parsing
        String content = Encoding.UTF8.GetString(data);
        
        // do something
        }
        catch (Exception ex)
        {
        throw(ex);
        }
    }
