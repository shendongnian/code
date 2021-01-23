    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
        string[] strArray = txtSource.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        Int32 i = 0;
        int iLength = strArray.Length;
        foreach (string item in strArray)
        {
            //Thread.Sleep(250);
            string returnMessage = DoAction(item).Replace(nl,"");
            i++;
            backgroundWorker.ReportProgress(i/iLength , item + " ..." + returnMessage);                
        }
    }
