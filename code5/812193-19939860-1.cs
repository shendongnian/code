    var outputDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
    var sourceDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
    var sourceFiles = sourceDirectory.GetFiles();
    var extensions = new List<string> { ".xml", ".dat", ".txt", ".csv", ".zip", ".doc" };
    
    foreach (var item in sourceFiles)
    {
        string extension = Path.GetExtension(item);
        
        if(extensions.Contains(extension))
        {
            FileHelper.Copy(item, outputDirectory);
            FileHelper.Move(FileHelper.Zip(item), new DirectoryInfo(@"G:\Local\Syndicationtest\History"));
        }   
    }
