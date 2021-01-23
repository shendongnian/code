    public void bw_Convert_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i <= 1000000; i++)
        {   
            if (i % 10000 == 0)
               bw_Convert.ReportProgress(i);
            // do something
        }
    }
