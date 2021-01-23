    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(typeof(this), new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }
