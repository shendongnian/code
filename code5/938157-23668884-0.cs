    public IEnumerable<string> GetFiles(string rootPath, string [] fileNameStartChars, string[] extensionsFilter)
            {
                FileSystemInfo[] fsi = null;
                for(int i = 0; i < fileNameStartChars.Length; i++)
                {
                    for(int k = 0; k<extensionsFilter.Length; k++)
                    {
                        fsi = new DirectoryInfo(rootPath).GetFileSystemInfos(fileNameStartChars[i]+extensionsFilter[k]);
    
                        if (fsi.Length > 0)
                        {
                            for (int j = 0; j < fsi.Length; j++)
                            {
                              /// .Name returns the filename with extension..if you need, please implement here a substring for eliminate the extension of the file
                                yield return fsi[j].Name;
                            }
                        }
                    }
                    
                }
               
            }
