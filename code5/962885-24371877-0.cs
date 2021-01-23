    //This goes in your Form1
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(WorkThread);
            t.Start();
        }
        private void WorkThread()
        {
            DoSomeWork w = new DoSomeWork();
            w.Work();
            while (w.progress < 100)
            {
                UpdateFromThread(w.progress);
                Thread.Sleep(100);
            }
        }
        private void UpdateFromThread(int progress)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker MyDelegate = delegate { UpdateFromThread(progress); };
                this.Invoke(MyDelegate);
            }
            else
            {
                progressBar1.Value = progress;
            }
        }
    //Class to do some work.
    class DoSomeWork
    {
        public int progress { get; set; }
        public DoSomeWork()
        {
            progress = 0;
        }
        public void Work()
        {
            Thread t = new Thread(WorkThread);
            t.Start();
        }
        private void WorkThread()
        {
            for (int i = 0; i < 100; i++)
            {
                progress += 1;
                Thread.Sleep(250);
            }
        }
    }
