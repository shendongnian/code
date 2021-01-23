    try
    {
        StreamReader reader = new StreamReader(filename);
       // Reading the stream
    }
    finally
    {
        if(reader != null)
        {
            reader.Dispose();
        }
    }
