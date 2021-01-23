    string customValue = string.Empty;
    string appData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    appData = Path.Combine(appData, "MyAppName");
    if(!Directory.Exists(appData))
        Directory.CreateDirectory(appData);
    string appDataFile = Path.Combine(appData, "MyAppNameSettings.txt");
    if(File.Exists(appDataFile))
        customValue = File.ReadAllText(appDataFile);
    else
    {
        customValue = AskUserForTheFirstTimeValue();
        File.WriteAllText(appDataFile, customValue);
    }
