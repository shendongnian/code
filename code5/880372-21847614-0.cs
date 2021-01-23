        BackgroundWorker work = null;
        private void button1_Click(object sender, EventArgs e)
        {
            work = new BackgroundWorker();
            work.DoWork += new DoWorkEventHandler(work_DoWork);
            work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(work_RunWorkerCompleted);
            work.RunWorkerAsync();
        }
        void work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //"hi" will get popped up here
            MessageBox.Show(e.Result.ToString());
        }
        void work_DoWork(object sender, DoWorkEventArgs e)
        {
            //Setting some value in e.Result
            e.Result = "hi";
        }
