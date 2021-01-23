    private void raisePropertyChanged(string name)
    {
      Dispatcher.InvokeAsync(()=>
      {
        if(PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(name));
      });
    }
