     public static void SynchFolders(string SourceUNC, string TargetUNC)
        {
            DirectoryInfo StartDirectory = new DirectoryInfo(SourceUNC);
            DirectoryInfo EndDirectory = new DirectoryInfo(TargetUNC);
            // Copy Files
            foreach (FileInfo file in StartDirectory.EnumerateFiles())
            {
                using (FileStream SourceStream = file.OpenRead())
                {
                    string dirPath = StartDirectory.FullName;
                    string outputPath = dirPath.Replace(StartDirectory.FullName, EndDirectory.FullName);
                    using (FileStream DestinationStream = File.Create(outputPath + "\\" + file.Name))
                    {
                        SourceStream.CopyToAsync(DestinationStream);
                    }
                }
            }
            // Copy subfolders
            var folders = StartDirectory.EnumerateDirectories();
            foreach (var folder in folders)
            {
                // Create subfolder target path by concatenating folder name to original target UNC
                string target = Path.Combine(TargetUNC, folder.Name);
                Directory.CreateDirectory(target);
                // Recurse into the subfolder
                SynchFolders(folder.FullName, target);
            }
        }
