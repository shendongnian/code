    public static void ProcessDirectory(DirectoryInfo directory)
    {
        // Define extension to match
        var extensions = new[] { "jpg", "jpeg", "bmp", "png", "gif" };
        foreach (FileInfo file in directory.EnumerateFiles())
        {
            // Check if extension matches
            if(extensions.Contains(file.Extension))
            {
                // Copy file to Destination
                file.CopyTo(@"C:\Destination");
            }
            else
            {
                // Copy file to Dump
                file.CopyTo(@"C:\Dump");
            }
        }
    }
