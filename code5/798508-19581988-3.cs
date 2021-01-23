    public event PropertyChangedEventHandler PropertyChanged;
    public void NotifyPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this,new PropertyChangedEventArgs(name));
        }
    }
