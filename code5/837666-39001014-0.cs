    public bool IsFileLocked(string filePath)
    {
        try
        {
            //Open the file exclusively
            using (File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None)) { }
        }
        catch (IOException e)
        {
            var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }
        return false;
    }
