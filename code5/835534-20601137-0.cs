    static bool fileExists = false;
    int fileCount = 0;
    foreach(string fl in files)
        {
            if(File.Exists(System.IO.Path.Combine(Dir,fl)))
            {
               fileCount++;
            }
        }
    if (fileCount == files.Count)
        {
            fileExists = true;
        }
