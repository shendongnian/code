    public bool _isFocused;
    public bool IsFocused
    {
       get { return _isFocused; }
       set
       {
          if (value == _isFocused)
             return;
          _isFocused = value;
          OnIsFocusedChanged(value);
          RaisePropertyChanged(() => IsFocused);
    }
    private void OnIsFocusedChanged(bool isFocused)
    {
       if (isFocused)
          IsFocusedText = "tab is focused";
       else
          IsFocusedText = "tab is NOT focused";
    }
    public bool _isFocusedText;
    public bool IsFocusedText
    {
       get { return _isFocusedText; }
       set
       {
          if (value == _isFocusedText)
             return;
          _isFocusedText = value;
          RaisePropertyChanged(() => IsFocusedText);
    }
