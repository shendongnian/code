    public bool CanWriteToPath(string folderPath) 
    {
        try 
        { 
            var ds = Directory.GetAccessControl(folderPath);
            return true;
        } catch (UnauthorizedAccessException)
        {
            return false;
        }
    }
