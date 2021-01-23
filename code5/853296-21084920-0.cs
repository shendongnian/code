     private void Walkdirectoryfulldepth(string dirPath, List<string> data)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                var sorted = dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly).ToList();
                DirectoryInfo[] subDirs = dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
                string[] strDir=new string[subDirs.Count()];
                int i =0;
                foreach (var item in subDirs)
                {
                    strDir[i] = item.FullName;
                    i++;
                }
                 NumericComparer nc = new NumericComparer();
                 Array.Sort(strDir, nc);
                 foreach (var item in strDir)
                {
                    data.Add(Path.GetFileName(item));
                    Walkdirectoryfulldepth(item, data);
                }
                //foreach (var item in subDirs)
                //    Walkdirectoryfulldepth(item.FullName, data);
    
            }
