    using System.IO;
    private void Test()
    {
        string applicationFolder = GetApplicationFolder();
    }
    private static string GetApplicationFolder()
    {
        var applicationName = "MyCoolRssReader";
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string applicationFolder = Path.Combine(folderPath, applicationName);
        bool exists = Directory.Exists(applicationFolder);
        if (!exists)
        {
            Directory.CreateDirectory(applicationFolder);
        }
        return applicationFolder;
    }
