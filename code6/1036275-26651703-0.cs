    delegate void DelegateDoWork(int number);
        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(DoWork).Start();
        }
        public void ProgressBar(int i)
        {
            if (label1.InvokeRequired)
            {
                var d = new DelegateDoWork(ProgressBar);
                this.Invoke(d, i);
               
            }
            else
                label1.Text = i.ToString();
        }
        public void DoWork()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                ProgressBar(i);
            }
        }
