    private void FtpProgress_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do the maximum you can do here...
        // ...
    
        if ImGoingToUseStringArray
        {
            string[] files = ....
            ResumeWithStringArray(files, sender, e);
        }
        else
        {
            FileInfo[] dirflist = ....
            ResumeWithFileInfo(dirfList, sender, e);
        }
    }
    private void ResumeWithStringArray(string[] files, object sender, DoWorkEventArgs e)
    {
        // ...
        // you can also call another core Function from here
        sendMyFile(args)
    }
    private void ResumeWithFileInfo(FileInfo[] dirflist, object sender, DoWorkEventArgs e)
    {
        // ...
        // you can also call another core Function from here
        sendMyFile(args)
    }
