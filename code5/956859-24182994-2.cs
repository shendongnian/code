    // using System.Configuration;
    // using System.IO;
    var fileMap = new ExeConfigurationFileMap();
    fileMap.ExeConfigFilename = File.Exists("XYZ.exe.config") ? "XYZ.exe.config" : "XYZ.config";
    string path = Path.Combine(Application.StartupPath, key);
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    var config = System.Configuration.Configuration; 
    config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
    config.AppSettings.Settings.Item(key).Value = path;
    config.Save(ConfigurationSaveMode.Modified);
