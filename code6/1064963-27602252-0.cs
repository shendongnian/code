    public static class FooClass
        {
            public void DeleteDirectory(string path)
            {
                foreach (string directory in Directory.EnumerateDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    File.Delete(file);
                }
                Directory.Delete(path);
            }
        }
