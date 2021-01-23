    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        //BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 0; i < 10000; i++)
        {
             sb.AppendLine(i.ToString());
        }
        SetText(textBoxOutput, sb.ToString());
    }
