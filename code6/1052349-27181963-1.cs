    GetPath("ConfigFiles/MyConfig.xml") // returns the full path to MyConfig.xml
    private string GetPath(string relativePath)
    {
        var appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string pattern = @"^(.+\\)(.+exe)$";
        Regex regex = new Regex(pattern, RegexOptions.None);
        var match = regex.Match(appPath);
        return System.IO.Path.GetFullPath(match.Groups[1].Value + relativePath);
    }
