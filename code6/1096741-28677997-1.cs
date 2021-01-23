    [DllImport("shell32.dll")]
    static extern int FindExecutable(string lpFile, string lpDirectory, [Out] StringBuilder lpResult);
    
    public static async void OpenImage(string imagePath, int time)
    {
        var exePathReturnValue = new StringBuilder();
        FindExecutable(Path.GetFileName(imagePath), Path.GetDirectoryName(imagePath), exePathReturnValue);
        var exePath = exePathReturnValue.ToString();
        var arguments = "\"" + imagePath + "\"";
    
        // Handle cases where the default application is photoviewer.dll.
        if (Path.GetFileName(exePath).Equals("photoviewer.dll", StringComparison.InvariantCultureIgnoreCase))
        {
    		arguments = "\"" + exePath + "\", ImageView_Fullscreen " + imagePath;
    		exePath = "rundll32";
        }
    
        var process = new Process();
        process.StartInfo.FileName = exePath;
        process.StartInfo.Arguments = arguments;
    
        process.Start();
    
        await Task.Delay(time);
    
        process.Kill();
        process.Close();
    }
