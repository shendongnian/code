    private void button1_Click(object sender, EventArgs e)
    {
       
        label1.Text = "Loading";
        backgroundWorker1.RunWorkerAsync();
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        load();
    }
    
    private void load()
    {
       System.Threading.Thread.Sleep(1000);
       if(InvokeRequired)
          this.Invoke(new Action(()=>label1.Text = "Done"));
    }
