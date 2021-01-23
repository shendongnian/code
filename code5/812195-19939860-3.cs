    var outputDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
    var sourceDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
    FileInfo[] sourceFiles = sourceDirectory.GetFiles();
    var extensions = new List<string> { ".xml", ".dat", ".txt", ".csv", ".zip", ".doc" };
    
    foreach (FileInfo item in sourceFiles)
    {        
        if(extensions.Contains(item.Extension))
        {
            FileHelper.Copy(item, outputDirectory);
            FileHelper.Move(FileHelper.Zip(item), new DirectoryInfo(@"G:\Local\Syndicationtest\History"));
        }   
    }
