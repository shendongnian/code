    public static string getDirectory(string path, string subpath)
    {
        RegistryKey key = checkKey(path);
        if (key != null && key.GetValue(subpath) != null)
        {
            return key.GetValue(subpath).ToString();
        }
        else
        {
            return null;
        }
    }
