    private void NotifyOnPropertyChanged([CallerMemberName] string caller = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
