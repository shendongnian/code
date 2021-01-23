    var fileInfoArray = DirectoryInfo.GetFiles(@"path");
    
    foreach(var fInfo in fileInfoArray)
    {
       Console.WriteLine(fInfo.CreationTime.ToString());
       Console.WriteLine(fInfo.LastWriteTime.ToString());
       Console.WriteLine(fInfo.LastAccessTime.ToString());
    }
