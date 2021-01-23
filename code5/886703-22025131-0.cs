    //Finding the file
    var commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    var programPath = Path.Combine(commonPath, "Your Programs Name");
    var settingFile = Path.Combine(programPath, "settings.xml");
    
    //Saving settings
    Directory.CreateDirectory(programPath);
    var serializer = new XmlSerializer(typeof(YourCustomSettingsType));
    using(var fs = File.Open(settingFile, FileMode.Create))
    {
        serializer.Serialize(fs, yourCustomSettings);
    }
