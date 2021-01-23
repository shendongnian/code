    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        //This runs on the background thread so this is where you do long running process
        ShowSystem(false);
        //You should NOT update the UI from here:
        //this.BusyContent = "Please Wait...";
        //this.IsBusy = true;
        //Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => OnPropertyChanged("Network")));
    }
