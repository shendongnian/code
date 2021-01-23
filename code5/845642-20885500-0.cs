    bool encrypted = IsEncryptedFile(fileName);
    Stream s = null;
    try
    {
        if (encrypted)
        {
            s = new EncryptedStreamReader(fileName);
        }
        else
        {
            s = new StreamReader(fileName);
        }
 
        // Read from s
    }
    finally
    {
        if (s != null)
            s.Close();
    }
