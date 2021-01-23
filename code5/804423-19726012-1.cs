    public class MyClassUsingWorker
    {
        // have reference to the class where the worker will be running
        private MyWorkerClass mwc = null;
    
        // run the worker
        public void RunMyWorker()
        {
            mwc = new MyWorkerClass();
            BackgroundWorker backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(mwc.RunStuff);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string strSpecialMessage = mwc.ErrorMessage;
        
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = e.Result.ToString();
            }
        }
    }
