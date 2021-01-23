    public static string FindFileInPath(string name)
    {
        foreach (string path in Environment.ExpandEnvironmentVariables("%path%").Split(';'))
        {
            string filename;
            if (File.Exists(filename = Path.Combine(path, name)))
            {
                return filename; // returns the absolute path if the file exists
            }
        }
        return null; // will return null if it didn't find anything
    }
