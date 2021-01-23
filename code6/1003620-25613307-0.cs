    public Main()
    {
        isDbAvail = new BackgroundWorker();
        isDbAvail.WorkerReportsProgress = true;
        isDbAvail.DoWork += isOnline;
        isDbAvail.ProgressChanged += rewriteOnlineStatus; 
        isDbAvail.RunWorkerAsync();
    }
    private void rewriteOnlineStatus(object sender, ProgressChangedEventArgs e)
    {        
        changeStatus((bool)e.UserState);
    }
    private void isOnline(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            Console.WriteLine("Checking database connection");
            Subs.Connection connection = new Subs.Connection();
            isDbAvail.ReportProgress(0, connection.isDbAvail);
            System.Threading.Thread.Sleep(8000);
        }
    }
