    private string _text;
    private ObservableCollection<string> _result;
    public string Text
    {
      get 
      {
        return _text;
      }
      set
      {
        if (_text == value)
        {
          return;
        }
        _text = value;
        OnPropertyChanged("Text");
        RefreshResult();
    }
    public ObservableCollection<string> Result
    {
      get 
      {
        return _result;
      }
    }
    private void RefreshResult()
    {
      // Do the search
      // Update the _result collection
    }      
