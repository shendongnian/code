    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        splashScreen.Close();
        this.Form2.Invoke((Action)delegate()
        {
            this.Form2.Show(); // does not work
            System.Windows.Threading.Dispatcher.Run();
        });
    }
