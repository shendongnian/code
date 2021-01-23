    public string GetMyAppDir()
    {
        var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
        var dir = path.AbsolutePath + File.Separator + "MyAppFolder";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        return dir;
    }
