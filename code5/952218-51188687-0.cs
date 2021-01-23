    var shellFile = ShellFile.FromFilePath(filePath);
    
    shellFile.Properties.System.Author.Value = new string[] { "MyTest", "Test" };
    shellFile.Properties.System.Music.Artist.Value = new string[] { "MyTest", "Test" };
    shellFile.Properties.System.Music.DisplayArtist.Value = "Test";
