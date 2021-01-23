    private void simpleButton1_Click(object sender, EventArgs e)
    {
        bw.ReportsProgress = true;
        bw.RunWorkerAsync();                      
        frm.ShowDialog();
    }
    private void GetData()
    {
        for (int i = 0; i < 500000; i++)
        {
            datatable.Rows.Add(new object[] { "raj", "raj", "raj", i });
            if(i%1000==0) bw.ReportProgress((int)((i/500000f)*100));
        }
    }
    void bw_DoWork(object sender,DoWorkEventArgs e)
    {
        GetData();
    }
    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //update your secondary form's UI here. I'm supposing you have a ProgressBar
        //on your form named 'pbr' (make that control public)
        frm.pbr.Value = e.ProgressPercentage;
    }    
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        frm.Hide();
    }    
