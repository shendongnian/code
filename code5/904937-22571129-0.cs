    void checkDIR(string Path)
    {
       foreach(string childpath in Directory.GetDirectories(path))
        {
             checkpaths(childpath);
        }
    }
    void checkpaths(string Path)
    {
         //check if directory contains directories and files
       foreach(string childpath in Directory.GetDirectories(path))
        {
             checkpaths(childpaths);//recursion
        }
    }
