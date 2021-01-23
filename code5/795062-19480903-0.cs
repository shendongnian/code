                Action<string, string> action = null;
                action = (source,dest) =>
                    {
                        if(Directory.Exists(source))
                        {
                            DirectoryInfo sInfo = new DirectoryInfo(source);
                            if (!Directory.Exists(dest))
                            {
                                Directory.CreateDirectory(dest);
                            }
                            Array.ForEach(sInfo.GetFiles("*"), a => File.Copy(a.FullName, Path.Combine(dest,a.Name)));
                            foreach (string dir in Directory.EnumerateDirectories(source))
                            {
                                string sSubDirPath = dir.Substring(source.Length+1,dir.Length-source.Length-1);
                                string dSubDirPath = Path.Combine(dest,sSubDirPath);
                                action(dir, dSubDirPath);
                            }
                        }
                    };
                action(@"C:\source", @"C:\dest");
