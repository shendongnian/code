    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        splashScreen.Close();
        this.Form2.Dispatcher.Invoke((Action)delegate()
        {
            this.Form2.Show(); // works fine
        });
    }
