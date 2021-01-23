        public event EventHandler Foo;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            //...
            backgroundWorker1.ReportProgress(0, new Action(() => {
                var handler = Foo;
                if (handler != null) handler(this, EventArgs.Empty);
            }));
            //...
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (e.UserState != null) ((Action)e.UserState)();
            else this.progressBar1.Value = e.ProgressPercentage;   // optional
        }
