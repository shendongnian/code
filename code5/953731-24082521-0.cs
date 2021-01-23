    public bool IsFileLocked(string filePath)
    {
        try
        {
            using (File.Open(filePath, FileMode.Open)){}
        }
        catch (IOException e)
        {
            retturn true;
        }  
        return false;
    }
