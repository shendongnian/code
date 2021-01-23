            FileInfo CurrentExeInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            // Current Folder + bin\Debug
            DirectoryInfo BinDebug = new DirectoryInfo( Path.Combine( CurrentExeInfo.Directory.FullName,  @"bin\Debug") );
            // Subfolders in \bin\Debug
            Console.WriteLine(BinDebug.FullName);
            string[] Dirs = Directory.GetDirectories(BinDebug.FullName, "*", SearchOption.TopDirectoryOnly);
            // In each localization folder ...
            foreach (string Dir in Dirs)
            {
                DirectoryInfo DirInfo = new DirectoryInfo(Dir);
                // ... Resource files
                string[] RFiles = Directory.GetFiles(Dir, "*.resources.dll");
                foreach (string RFile in RFiles)
                {
                    FileInfo RFileInfo = new FileInfo(RFile);
                    bool DoCopy = false;
                        
                    // No underscore in resource name
                    if (!RFileInfo.Name.Contains("_") || RFileInfo.Name.IndexOf("_") == 0)
                    {
                        DoCopy = true;
                    }
                    // underscore in resource name
                    // --> Have to check if already a copy 
                    else
                    { 
                        // prefix removal
                        int PrefixIndex = RFileInfo.Name.IndexOf("_");
                        string TestFilename = RFileInfo.Name.Substring(PrefixIndex + 1);
                        if (!File.Exists(Path.Combine(Dir, TestFilename)))
                        {
                            // File without underscore does not exist, so must copy
                            DoCopy = true;
                        }
                    }
                    if (DoCopy)
                    {
                        // Copy file
                        string NewFileName = Path.Combine(Dir, DirInfo.Name.ToUpper() + "_" + RFileInfo.Name);
                        Console.WriteLine("Copying " + RFile + " -> " + NewFileName);
                        File.Copy(RFile, NewFileName, true);
                    }
                }
            }
