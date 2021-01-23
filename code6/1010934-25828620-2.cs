    private string _text { get; set; }
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
             
            if(_text.Length  > 5)
            // Enable button here
            // and command does not enable Buttons they are basically report the clicks events.
            IsButtonEnabled = true;
            OnPropertyChanged("Text");
        }
    }
