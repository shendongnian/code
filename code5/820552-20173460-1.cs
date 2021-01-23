    protected void OnPropertyChanged(string propertyName)
    {
      var handler = this.PropertyChanged;
      if (null != handler)
        handler(this, new PropertyChangedEventArgs(propertyName));
    }
