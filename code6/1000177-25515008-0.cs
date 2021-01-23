    foreach (string file in msu)
    {
        string KB = GetKBNumber(file);
        Expand.MSU(file, TempDirectory + "\\" + KB);
        List<string> versions = GetVersionNumbers(TempDirectory + "\\" + KB);
    
        foreach (string version in versions)
        {
            olvOutput.AddObject(new { kbAspectName = KB, versionAspectName = version });
        }
        PerformStep();
    }
