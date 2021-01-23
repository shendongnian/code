    // Reliably get the .EXE directory, this works for both Form and Console applications:
    var AssemblyDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    
    // Option 1 is set on load:
    Directory.SetCurrentDirectory(AssemblyDirectory);
        
    // Option 2 is use full paths for anything opening files:
    File.ReadAllText(AssemblyDirectory + "\\SomeFile.txt");
