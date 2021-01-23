    public bool ThrobberVisible
    {
      get { return _throbberVisible; }
      set
      {
        if (value != _throbberVisible)
        {
          _throbberVisible = value;
          this.OnPropertyChanged("ThrobberVisible");
        }
      }
    }
