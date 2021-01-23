    Console.WriteLine("Enter Folder Name");
    string userInput = Console.ReadLine();
    
    // Check to verify if the user input is valid
    if(Directory.Exists(userInput))
    {
        DirectoryInfo di = new DirectoryInfo(userInput);
        FileInfo[] fileType = di.GetFiles("*.*", SearchOption.TopDirectoryOnly);
        Directory.SetCurrentDirectory(userInput);
        Console.WriteLine("{0}", userInput );
    }
    else 
        Console.WriteLine("{0} doesn't exist", userInput );
     
    
