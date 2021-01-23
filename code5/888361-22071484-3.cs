    void m_bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       pictureBox1.Visible = true;
       pictureBox1.Refresh();
    
       progressBar1.Value = e.ProgressPercentage;
       string dirName = e.UserState.ToString();
    
       lblStatus.Text = "Processing" + dirName + "....." + progressBar1.Value.ToString() + "%";
    }
