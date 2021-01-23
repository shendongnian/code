    public string Title {
      get {
        return _title;
      }
      set {
        if (_title == value) {
          return;
        }
        _title = value;
        RaisePropertyChanged(() => Title);
      }
    }
    public RelayCommand ButtonCommand { get; private set; }
    private bool CanEdit(string title) {
      int idValue;
      bool result = Int32.TryParse(title, out idValue);
      if (!result) {
        return false;
      }
      return idValue > 0;
    }
    ctor() {
      ButtonCommand = new RelayCommand(() => Debug.WriteLine("Called"), () => CanEdit(Title));
    }
