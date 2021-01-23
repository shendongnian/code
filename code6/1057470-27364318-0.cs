            public void Recursion(string path, ref IList<string> paths)
            {
                paths.Add(path);
                if(Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    paths.Add(directory.FullName);
                    
                    foreach (var file in directory.EnumerateFiles())
                    {
                        Recursion(file.FullName, ref paths);
                    }
    
                    foreach (var dir in directory.EnumerateDirectories())
                    {
                        Recursion(dir.FullName, ref paths);
                    }
                }
            }
