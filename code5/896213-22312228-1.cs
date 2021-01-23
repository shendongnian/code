    private static ArrayList GenerateFileList(string Dir)
    {
        ArrayList fils = new ArrayList();
        bool Empty = true;
        try
        {
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }
        }
        catch(UnauthorizedAccessException e)
        {
            // I believe that's the right exception to catch - compare with what you get
            return new ArrayList();
        }
            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                    // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }
        foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
        {
            foreach (object obj in GenerateFileList(dirs))
            {
                fils.Add(obj);
            }
