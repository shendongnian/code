            if (Directory.Exists(dirPath) && Directory.Exists(DestinPath))
            {
                DirectoryInfo di = new DirectoryInfo(dirPath);
                foreach (var file in di.GetFiles())
                {
                    string destinFile = DestinPath + "\\" + file.Name;
                    if (File.Exists(destinFile))
                    {
                        continue;
                    }
                    else
                        file.CopyTo(destinFile);
                }
            }
