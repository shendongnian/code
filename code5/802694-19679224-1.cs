    public RelayCommand<CancelEventArgs> BackKeyPressCommand { get; private set; }
    this.BackKeyPressCommand = new RelayCommand<CancelEventArgs>(this.BackKeyPress)
    private void BackKeyPress(CancelEventArgs e)
    {
    }
