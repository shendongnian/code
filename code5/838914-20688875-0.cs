    public void Read_in()
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerAsync();
        
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        using (StreamReader sr = new StreamReader("in.txt"))
        {
            while (!sr.EndOfStream)
            {
                Data d = new Data
                {
                    a = sr.ReadLine()
                };
                if(this.InvokeRequired)
                {
                     this.Invoke((MethodInvoker)delegate
                     {
                         _list.Add(d);
                         Controls.Add(d.pb);
                     });
                     
                }
                else
                {
                     _list.Add(d);
                     Controls.Add(d.pb);
                }
            }
        }
    }
