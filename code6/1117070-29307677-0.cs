    public string Text
    {
        get { return _text; }
        set
        {
            if (_text != value)
            {
                _text = value;
                OnTextChanged();
            }
        }
    }
