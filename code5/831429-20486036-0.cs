    public bool IsFileOpen(FileInfo file)
    {
        FileStream stream = null;
    
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            // Is Open
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    
        //Not Open
        return false;
    }
