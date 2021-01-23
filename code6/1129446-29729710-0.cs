            DirectoryInfo dir = new DirectoryInfo(drive);
            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name.Contains("something"))
                    {
                        //do something.... xD
                    }
                }
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        //string temppath = Path.Combine(destDirName, subdir.Name);
                        searchDirectory(subdir.FullName, doSubdirs);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            { }
