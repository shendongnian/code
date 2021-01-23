    void Main()
    {
    	 string projectsPath = Path.Combine(@"D:\New folder", "Stackoverflow");
            string projectPath = Path.Combine(projectsPath);
            string packagesFolder = Path.Combine(projectPath, "Source");
        DirectoryInfo dInfo = new DirectoryInfo(packagesFolder);
        DirectoryInfo[] subDirs = dInfo.GetDirectories();
        foreach (DirectoryInfo dir in subDirs)
        {
            string packageInfo = String.Empty;
            string[] information;
            if (dir.EnumerateFiles().Any(item => item.Name == "test.txt"))
            {
                FileInfo file = dir.EnumerateFiles().First(item => item.Name == "test.txt");
                using (StreamReader sr = file.OpenText())
                {
                    packageInfo = sr.ReadToEnd();
                }
            }
		}
    }
