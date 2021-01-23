    public sealed class MyBackgroundWorker : BackgroundWorker
    {
        public MyBackgroundWorker(ProgressBar pBar)
        {
            this.MyProgressBar = pBar;
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = false;
            this.DoWork += MyBackgroundWorker_DoWork;
            this.ProgressChanged += MyBackgroundWorker_ProgressChanged;
            this.RunWorkerCompleted += MyBackgroundWorker_RunWorkerCompleted;
        }
        public ProgressBar MyProgressBar { get; private set; }
        void MyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finish");
        }
        void MyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SendMail();
        }
        void MyBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Boolean either = true;          // These are your choices
            if (either)
            {
                // If the ProgressBar has been properly configured regarding
                //
                // this.myProgressBar.Minimum
                //   and
                // this.myProgressBar.Maximum
                //
                // you can simply call
                
                this.MyProgressBar.PerformStep();
            }
            else
            {
                // If the Progressbar has not been properly configured,
                // you have to assign the value provided by
                // ProgressChangedEvents e like this
                this.MyProgressBar.Value = e.ProgressPercentage;
            }
   
        }
        private Boolean SendMail()
        {
            // foreach mail in MailsToSend ...
            // Snip - I assume your code for sending mails works correctly
            try
            {
                // Snip
            }
            catch (Exception ex)
            {
                // Snip
            }
            finally
            {
                this.ReportProgress( (100 * cntMailsSent) / cntTotalMailsToSend);
            }
            // quit = true;                 // What do you use this for?
        }
    }
