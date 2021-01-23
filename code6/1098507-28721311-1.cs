    private void OnPropertyChanged(string p)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(p));
    }
