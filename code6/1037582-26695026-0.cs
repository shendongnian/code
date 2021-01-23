    _rowAClickCommand = new DelegateCommand(() =>
    {
        MessageBox.Show("ACalled");
        _rowBClickCommand = new DelegateCommand(() =>
        {
            MessageBox.Show("BCalled");
        });
    
        OnPropertyChanged("RowBClickCommand");   
    });
