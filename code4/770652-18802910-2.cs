    private long diskSizeInGB = 1;
    const long GB = 1024 * 1024 * 1024;
    long filesizesProcessedInGB = 0;
    
    private void button4_Click(object sender, EventArgs e)
    {
        // get drive info
        var cdrive = DriveInfo.GetDrives().First(d => d.Name == @"C:\");
        // calculate max used bytes
        diskSizeInGB = (cdrive.TotalSize - cdrive.TotalFreeSpace) / GB;
        // backupprocess, async!
        bgwScan.RunWorkerAsync();
    }
    
    private void bgwScan_DoWork(object sender, DoWorkEventArgs e)
    {
        Scanner(@"C:\"); // start scaning/backuping/copying recursively
    }
    
    void Scanner(string path)
    {
        foreach (var file in Directory.EnumerateFiles(path, "*.*"))
        {
            var fileInfo = new FileInfo(file);
            filesizesProcessedInGB += (fileInfo.Length / GB);  
            // Copy / backup / whatever you want with a file
        }
        // calculate progress percentager and report
        bgwScan.ReportProgress((int)(100 * filesizesProcessedInGB / diskSizeInGB));
    
        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            try
            {
                Scanner(dir);
            }
            catch (Exception)
            {
                Trace.WriteLine(dir + " error");
            }
        }
    }
    
    private void bgwScan_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // update progressbar
        progressBar1.Value = e.ProgressPercentage;
    }
