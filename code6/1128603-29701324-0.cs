    private string _textblock;
    public string TextBlock
    {
        get { return _textblock; }
        set { 
                _textblock = value.ToUpperInvariant(); 
                NotifyPropertyChanged("TextBlock"); 
            }
    }
             
