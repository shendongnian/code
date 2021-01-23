            public void Recursion(string path, IList<string> paths)
            {
                paths.Add(path);
                if(Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    paths.Add(directory.FullName);
                    
                    foreach (var file in directory.EnumerateFiles())
                    {
                        paths.Add(file.FullName);
                    }
    
                    foreach (var dir in directory.EnumerateDirectories())
                    {
                        Recursion(dir.FullName, paths);
                    }
                }
            }
