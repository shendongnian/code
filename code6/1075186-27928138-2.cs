    DirectoryInfo folderInfo = new DirectoryInfo("C:\\Windows");
    Console.WriteLine("Enter Folder Name");
    string userInput = Console.ReadLine();
    string subFolder = Path.Combine(folderInfo.FullName, userInput);
    // Check to verify if the user input is valid
    if(Directory.Exists(subFolder))
    {
        FileInfo[] fileType = folderInfo.GetFiles(Path.Combine(userInput, "*.*"), 
                                         SearchOption.TopDirectoryOnly);
        Directory.SetCurrentDirectory(subFolder);
        Console.WriteLine("{0}", Directory.GetCurrentDirectory());
    }
    else 
        Console.WriteLine("{0} doesn't exist", subFolder);
     
