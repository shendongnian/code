    public SubViewModel(ViewModel vm)
    {
      _vm = vm;
    }
    private string _text;
    private ViewModel _vm;
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
    private void RefreshResult()
    {
      // Do something with the _text and manipulate the _vm.Rows?
    }
