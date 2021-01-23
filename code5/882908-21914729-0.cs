        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <=5; i++)
            {
                BackgroundWorker x = new BackgroundWorker();
                x.DoWork += x_DoWork;
                x.RunWorkerCompleted += x_RunWorkerCompleted;
                x.RunWorkerAsync();
            }
        }
        private bool cancelMessages = false;
        private Object dialogLock = new object();
        void x_DoWork(object sender, DoWorkEventArgs e)
        {
            
            // ... some work ...
            System.Threading.Thread.Sleep(5000); // five seconds worth of "work"
            if (true) // some error occurred
            {
                lock (dialogLock) // only one worker thread can enter here at a time
                {
                    if (!cancelMessages) // if error messages haven't been turned off, ask the user
                    {
                        // ask the user on the main UI thread:
                        // *Invoke() is SYNCHRONOUS, so code won't go continue until after "dlg" is dismissed
                        this.Invoke((MethodInvoker)delegate() {
                            MyDialog dlg = new MyDialog("Something went wrong.");
                            if (dlg.ShowDialog(this) == DialogResult.Cancel) 
                                cancelMessages = true;
                        });
                    }
                }
            }
        }
        public void x_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("RunWorkerCompleted");
        }
