    private void searchList_TextChanged(object sender, EventArgs e)
    {
        searchLabel.Visible = false;
        backgroundWorker.RunWorkerAsync();
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        //some code that needs time
        Thread.Sleep(1000);
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        SetLabelVisible(true);
    }
    private delegate void SetLabelVisibleDelegate(bool status);
    private void SetLabelVisible(bool status)
    {
        if (searchLabel.InvokeRequired)
            searchLabel.Invoke(new SetLabelVisibleDelegate(SetLabelVisible), status);
        else
            searchLabel.Visible = status;
    }
