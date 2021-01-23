    public static string[] GetDirectoryInfo(string path)
    {
        if (Directory.Exists(path))
        {
            try 
            { 
                //This call is failing on the new folder.
                return Directory.GetDirectories(path);
            }
            catch(UnauthorizedAccessException unAuthEx)
            {
                // Do nothing to eat exception
            }
        }
        return new string[0];
    }
