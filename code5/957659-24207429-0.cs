    /// <summary>
    /// Print the file
    /// </summary>
    /// <param name="value"></param>
    public static void Print(this FileInfo value)
    {
        if (!value.Exists)
            throw new FileNotFoundException("File doesn't exist");
        Process p = new Process();
        p.StartInfo.FileName = value.FullName;
        p.StartInfo.Verb = "Print";
        p.Start();
    }
