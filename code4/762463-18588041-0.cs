    BackgroundWorker bg;
    public Form1()
    {
        bg = new BackgroundWorker();
    }
    
    
    private void button1_Click(object sender, EventArgs e)
    {
             if(bg.IsBusy)
             {
                 // show the message
             }
             else
             {
                  bw.WorkerReportsProgress = true;
                  bw.DoWork += delegate {
                     SaveDetails();
                  };
                  bw.RunWorkerCompleted += delegate {
                     MessageBox.Show("Completed");
                  };
                  bw.RunWorkerAsync();
             }
    }
