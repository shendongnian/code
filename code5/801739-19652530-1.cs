    private System.Windows.Input.ICommand _clickCommand = new DelegateCommand((o) =>
            {
                this.StartStopLabel = "Stop";
                Task.Factory.StartNew(() =>
                {
                    //call service on a background thread here...
                });
            });
    public System.Windows.Input.ICommand ClickCommand { get { return _clickCommand; }}
