    private List<Code> codes;
    public List<Codes> Codes 
    { 
        get {return codes;}
        set 
        {
            codes = value;
            NotifyPropertyChanged("Codes");
        }
    }
    private void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
