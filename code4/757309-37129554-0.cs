    public static string ConvertRelativePathToAbsolutePath(string basePath, string path)
    {
        if (System.String.IsNullOrEmpty(basePath) == true || System.String.IsNullOrEmpty(path) == true) return "";
        //Gets a value indicating whether the specified path string contains a root.
        //This method does not verify that the path or file name exists.
        if (System.IO.Path.IsPathRooted(path) == true)
        {
            return path;
        }
        else
        {
            return System.IO.Path.GetFullPath(System.IO.Path.Combine(basePath, path));
        }
    }
