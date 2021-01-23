        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new InvokeDelegate(InvokeMethod));               
        }
        public delegate void InvokeDelegate();
        public void InvokeMethod()
        {
            this.Hide(); 
            this.Dispose();
        }
