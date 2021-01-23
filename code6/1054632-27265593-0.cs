    if (Directory.Exists(dirPath)) // Server A Directory Path, where the new file is creating
     {
             DirectoryInfo di = new DirectoryInfo(dirPath);
                foreach (var file in di.GetFiles())
                {
                    if (file.Exists)
                    {
                        continue;
                    }
                    else
                        file.CopyTo("DestinPath");//System B Path
                }
            }
