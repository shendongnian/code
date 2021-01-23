    public Visibility VisibilityOption
    {
      get { return _visibilityOption; }
      set
      {
        if (_visibilityOption != value)
        {
          _visibilityOption = value;
          OnPropertyChanged("VisibilityOption");
        }
      }
    }
