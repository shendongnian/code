    public static void Main()
    {
        var path = "\\my\\file\\path.foo";
        Console.WriteLine("Checking for file...");
        var fi = new FileInfo(path);
        if(!fi.Exists)
        {
            Console.WriteLine("File doesn't exist");
            return;
        }
        try
        {
            Console.WriteLine("Getting version...");
            const int VERSION_DEPTH = 4;
            var version = NativeFile.GetFileInfo(path);
            Console.WriteLine(version.Version.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + return ex.Message);
        }
    }
