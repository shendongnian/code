    public event PropertyChangedEventHandler PropertyChanged;
    protected void Notify(string propName)
    {
        if (this.PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
