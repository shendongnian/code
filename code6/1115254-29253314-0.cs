     try
    {
        var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
        using (StreamWriter sw = new StreamWriter(fs, Encoding.Default)
        {    
            sw.WriteLine(entry);
        }
    }
    catch (IOException ex)
    {
        throw ex;
    }
