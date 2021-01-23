    private void Form1_Load(object sender, EventArgs e)
            {
                BackgroundWorker BWorker = new BackgroundWorker();
                BWorker.DoWork += BWorker_DoWork;
                BWorker.RunWorkerAsync();
            }
    
            void BWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                // while(true) is meaningless.
                for (int i = 1; i < 11; i++)
                {
                    Action UpdateUI = () => { richTextBox1.Text += "here" + i + "/n"; };
                    this.BeginInvoke(UpdateUI);
                }
            }
