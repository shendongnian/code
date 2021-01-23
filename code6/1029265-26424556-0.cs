    private void btnFiles_Click(object sender, EventArgs e)
    {
        ...
        // pass folder name
        backgroundWorker1.RunWorkerAsync(folderBrowserDialog1.SelectedPath);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // get passed folder name
        string filePath = (string)e.Argument;
        ...
    }
