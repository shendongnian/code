        private void MyMethod()
        {
            bgw.RunWorkerAsync(); //this calls the DoWork event
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Expensive task
            //Calculate how far you through your task (ie has read X of Y bytes of file)
            bgw.ReportProgress(myInteger);
        }
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }
