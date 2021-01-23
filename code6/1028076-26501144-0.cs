    private string image_print()
    {
        ...Your code
        string newpath = string.Empty;
        if (!System.IO.File.Exists(filename_noext))
            System.IO.File.Copy(path, newpath);
        return newpath;
    }
