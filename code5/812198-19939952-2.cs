                        var outputDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
                        var sourceDirectory = new DirectoryInfo(@"G:\Local\Syndicationtest");
                        String[] FileExt = new String[] { ".xml", ".dat", ".txt", ".csv", ".zip", ".doc" };
                        var sourceFiles = sourceDirectory.GetFiles();
        
                        foreach (var item in sourceFiles)
                        {
                            if ((item.Contains(".")) && (FileExt.Contains(item.Substring(item.LastIndexOf("."), 4))))
                            {
                                FileHelper.Copy(item, outputDirectory);
                                FileHelper.Move(FileHelper.Zip(item), new DirectoryInfo(@"G:\Local\Syndicationtest\History"));
                            }
                        }
