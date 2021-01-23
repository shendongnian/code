    string program = "iexplore.exe";
    bool worked = false;
    foreach (string path in Environment.ExpandEnvironmentVariables("%path%").Split(';'))
    {
        string filename;
        if (File.Exists(filename = Path.Combine(path, program)))
        {
            System.Diagnostics.Process.Start(filename);
            worked = true;
        }
    }
