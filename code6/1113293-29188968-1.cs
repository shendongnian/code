    private static void Main()
    {
        // The directory to search for the file
        var searchPath = Path.GetDirectoryName(
            System.Reflection.Assembly.GetEntryAssembly().Location);
        // The name of the file we're searching for
        var fileName = "MyFile.txt";
        // Get the first match
        var theFile = Directory.GetFiles(searchPath, fileName).FirstOrDefault();
        // If the match is not null, we found the file
        if (theFile != null)
        {
            // Output some information about the file
            Console.WriteLine("Found the file: {0}", fileName);
            Console.WriteLine("The full path of the file is: {0}", theFile);
                
            // If it's a text file, here's one way to get the contents
            var fileContents = File.ReadAllText(theFile);
            Console.WriteLine("The contents of the file are:{0}{1}", Environment.NewLine, 
                fileContents);
            // If you need detailed info about the file, or 
            // want to write to it, create a FileInfo object
            var fileInfo = new FileInfo(theFile);
            // Output some detailed information about the file
            Console.WriteLine("The file was created on: {0}", fileInfo.CreationTime);
            Console.WriteLine("The file was last modified on: {0}", 
                fileInfo.LastWriteTime);
            Console.WriteLine("The file attributes are:");
            Console.WriteLine(" - ReadOnly: {0}", 
                Convert.ToBoolean(fileInfo.Attributes & FileAttributes.ReadOnly));
            Console.WriteLine(" - Hidden: {0}", 
                Convert.ToBoolean(fileInfo.Attributes & FileAttributes.Hidden));
            Console.WriteLine(" - System: {0}", 
                Convert.ToBoolean(fileInfo.Attributes & FileAttributes.System));
        }
    }
