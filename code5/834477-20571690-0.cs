    public string Text
    {
        get { return text; }
        set { if (value != null) { text = value; NotifyPropertyChanged("Text"); } }
    }
