    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        //You should only update UI properties from here using Dispatcher.CurrentDispatcher
        this.BusyContent = "Please Wait...";
        this.IsBusy = true;
        Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => OnPropertyChanged("Network")));
        //This runs on the background thread so this is where you do long running process
        ShowSystem(false);
    }
