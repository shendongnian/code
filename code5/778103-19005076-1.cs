    private void parseAndExportBtn_Click(object sender, EventArgs e)
    {
        progressBar1.MarqueeAnimationSpeed = 100;
        parseAndExportBtn.Enabled = false;
        selectDirectoryBtn.Enabled = false;
        status.Text = "Started searching files...";
        Task t = Task.Run(() => SearchFiles(selectTxcDirectory.SelectedPath));
        status.Text = "Finished searching files";
    }
    
