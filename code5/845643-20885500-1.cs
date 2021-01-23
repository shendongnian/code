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
            s = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        }
 
        // Read from s
    }
    finally
    {
        if (s != null)
            s.Close();
    }
