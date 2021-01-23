    var shellFile = ShellFile.FromParsingName(filePath);
    ShellPropertyWriter w = shellFile.Properties.GetPropertyWriter();
    try
    {
        w.WriteProperty(SystemProperties.System.Author, new string[] { "MyTest", "Test" });
        w.WriteProperty(SystemProperties.System.Music.Artist, new string[] { "MyTest", "Test" });
        w.WriteProperty(SystemProperties.System.Music.DisplayArtist, "Test");
    }
    catch (Exception ex)
    {
    }
    w.Close();
