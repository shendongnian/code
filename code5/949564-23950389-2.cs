    void YourMethod()
    {
       string spcdirectorypath = @"C:\Users";
       DirectoryInfo d = new DirectoryInfo(spcdirectorypath);
       WalkDirectoryTree(d)
    }
    static void WalkDirectoryTree(System.IO.DirectoryInfo root)
    {
        System.IO.FileInfo[] files = null;
        System.IO.DirectoryInfo[] subDirs = null;
        // First, process all the files directly under this folder 
        try
        {
            files = root.GetFiles("*.*");
        }
        // This is thrown if even one of the files requires permissions greater 
        // than the application provides. 
        catch (UnauthorizedAccessException e)
        {
            // You may decide to do something different here. For example, you 
            // can try to elevate your privileges and access the file again.
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
            // You may decide to do something different here. For example, you 
            // can log soething.
        }
        if (files != null)
        {
            foreach (System.IO.FileInfo fi in files)
            {
                // In this example, we only access the existing FileInfo object. If we 
                // want to open, delete or modify the file, then 
                // a try-catch block is required here to handle the case 
                // where the file has been deleted since the call to TraverseTree().
                string str = fi.FullName + "\n";
                richTextBox1.AppendText(str);
            }
            // Now find all the subdirectories under this directory.
            subDirs = root.GetDirectories();
            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                WalkDirectoryTree(dirInfo);
            }
        }            
    }
