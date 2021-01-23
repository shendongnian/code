    string[] array1 = Directory.GetFiles(@"path", "*.*", System.IO.SearchOption.AllDirectories);
    
    foreach (string name in array1)
    {
    
        FileInfo file = new FileInfo(name);
        
        Console.WriteLine("Checking file: " + file.Name);
        Console.WriteLine("File exists: " + file.Exists.ToString());
        
        if (file.Exists)
        {
           Console.WriteLine(file.CreationTime.ToString());
           Console.WriteLine(file.LastWriteTime.ToString());
           Console.WriteLine(file.LastAccessTime.ToString());
        }
    
    }
