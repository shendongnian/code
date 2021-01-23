    static void Main(string[] args)
    {
        int maxDepth = 5;
        string initialPath = @"D:\testFolders";
        createFolders(initialPath, maxDepth);
    }
    
    static void createFolders(string path, int depth)
    {
        depth--;
        for (int i = 0; i <= 10; i++)
        {
            string directory = Path.Combine(path, i.ToString());
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (depth > 0)
                createFolders(directory, depth);
        }
    }
