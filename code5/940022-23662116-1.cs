    private void btnTest_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int x = 0; x <= 5; x++)
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Start();
                timer.Interval = ((x + 1) * 100);
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    this.txtOutput.Text += "\r\r\n" + "  this out put equal to " + ((x + 1) * 100);
                }));
                Thread.Sleep((x + 1) * 100);
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    this.txtOutput.Text += "\r\r\n" + "  Ends x " + x;
                }));
            }
        }
