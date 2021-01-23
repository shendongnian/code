    <Button Content="Save" IsEnabled="{Binding FinishedDataTransfer}" ...
    bool _finishedDataTransfer = false;
    public bool FinishedDataTransfer
    {
        get { return _finishedDataTransfer; }
        set
        {
            _finishedDataTransfer = value;
            RaisePropertyChanged("FinishedDataTransfer");
        }
    }
