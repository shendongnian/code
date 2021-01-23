        private PowerShell ps = new PowerShell { };
        BackgroundWorker backgroundWorker = new BackgroundWorker();
 
        public void button3_Click(object sender, EventArgs e)
        {
 
            backgroundWorker.DoWork +=backgroundWorker_DoWork;
 
            backgroundWorker.RunWorkerAsync();
 
        }
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ps.AddScript("netsh trace start persistent=yes capture=yes tracefile=" + progpath + @"\nettrace.etl");
 
            ps.Invoke();
        }
        private void form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                ps.AddScript("netsh trace stop");
        }
