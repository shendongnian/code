    string folderName = @"C:\Test";
    
    if (!Directory.Exists(folderName))
    {
        Directory.CreateDirectory(folderName);
    }
    
    string readMeFileName = Path.Combine(folderName, "ReadMe.txt");
    string text = "This is used Test.";
    File.WriteAllText(readMeFileName , text);
    
    string jsFileName = Path.Combine(folderName, "Test.JS");
    File.Copy("Test.js", jsFileName);
