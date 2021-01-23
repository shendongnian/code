    static string sRootDir = @"<Path of Source directory>";
    static void BuildMSI()
            {                                  
                WixEntity[] weDir = new WixEntity[0];
                weDir = BuildDirInfo(sRootDir, weDir);
                var project = new Project("My product", weDir)
                {
                    GUID = Guid.NewGuid(),
                    //UI = WUI.WixUI_InstallDir,
                    Version = new Version(55, 0, 0, 0),
                    UpgradeCode = guidUpgradeCode, // Forwarded if upgrading existing product
                    MajorUpgradeStrategy = new MajorUpgradeStrategy
                    {
                        UpgradeVersions = VersionRange.OlderThanThis,
                        PreventDowngradingVersions = VersionRange.NewerThanThis,
                        NewerProductInstalledErrorMessage = "Newer version already installed"
                    }
                };
    
                project.BuildMsi(project);
            }
    
    
    
    static WixEntity[] BuildDirInfo(string sRootDir, WixEntity[] weDir)
            {
                DirectoryInfo RootDirInfo = new DirectoryInfo(sRootDir);
                if (RootDirInfo.Exists)
                {
                    DirectoryInfo[] DirInfo = RootDirInfo.GetDirectories();
                    List<string> lMainDirs = new List<string>();
                    foreach (DirectoryInfo DirInfoSub in DirInfo)
                        lMainDirs.Add(DirInfoSub.FullName);
                    int cnt = lMainDirs.Count;
                    weDir = new WixEntity[cnt + 1];
                    if (cnt == 0)
                        weDir[0] = new DirFiles(RootDirInfo.FullName + @"\*.*");
                    else
                    {
                        weDir[cnt] = new DirFiles(RootDirInfo.FullName + @"\*.*");
                        for (int i = 0; i < cnt; i++)
                        {
                            DirectoryInfo RootSubDirInfo = new DirectoryInfo(lMainDirs[i]);
                            if (!RootSubDirInfo.Exists)
                                continue;
                            WixEntity[] weSubDir = new WixEntity[0];
                            weSubDir = BuildDirInfo(RootSubDirInfo.FullName, weSubDir);
                            weDir[i] = new Dir(RootSubDirInfo.Name, weSubDir);
                        }
                    }
                }
                return weDir;
            }
