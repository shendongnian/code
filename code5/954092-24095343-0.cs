    public void createfolder(string directorypath)
    {
        // CREATE folder
        try
        {
            Directory.CreateDirectory(directorypath);
        }
        catch (Exception ex)
        { }
    }
    public void MoveFiles(string source, string destination, bool overwrite)
    {
        System.IO.DirectoryInfo inputDir = new System.IO.DirectoryInfo(source);
        System.IO.DirectoryInfo outputDir = new System.IO.DirectoryInfo(destination);
        try
        {
            if ((inputDir.Exists))
            {
                if (!(outputDir.Exists))
                {
                    createfolder(destination);
                    // outputDir.Create();
                }
                //Get Each files and copy
                System.IO.FileInfo file = null;
                foreach (System.IO.FileInfo eachfile in inputDir.GetFiles())
                {
                    file = eachfile;
                    if ((overwrite))
                    {
                        file.CopyTo(System.IO.Path.Combine(outputDir.FullName, file.Name), true);
                    }
                    else
                    {
                        if (((System.IO.File.Exists(System.IO.Path.Combine(outputDir.FullName, file.Name))) == false))
                        {
                            file.CopyTo(System.IO.Path.Combine(outputDir.FullName, file.Name), false);
                        }
                    }
                    System.IO.File.Delete(file.FullName);
                }
                //Sub folder access code       
                System.IO.DirectoryInfo dir = null;
                foreach (System.IO.DirectoryInfo subfolderFile in inputDir.GetDirectories())
                {
                    dir = subfolderFile;
                    //Destination path                   
                    if ((dir.FullName != outputDir.ToString()))
                    {
                        MoveFiles(dir.FullName, System.IO.Path.Combine(outputDir.FullName, dir.Name), overwrite);
                    }
                    System.IO.Directory.Delete(dir.FullName);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
