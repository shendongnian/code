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
    //loading settings
    try
    {
        var serializer = new XmlSerializer(typeof(YourCustomSettingsType));
        using(var fs = File.Open(settingFile, FileMode.Open))
        {
            yourCustomSettings = (YourCustomSettingsType)serializer.Deserialize(fs);
        }
    }
    catch
    {
        //If it fails to load just use the default settings (set in the constructor)
        yourCustomSettings = new YourCustomSettingsType();
        //Save the settings out so it won't fail next time.
        SaveSettings(yourCustomSettings);
    }
