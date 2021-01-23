    foreach (var obj in list)
    {
      if(obj is IObjectWithOnPropertyChangedMethod)
      {
        ((IObjectWithOnPropertyChangedMethod)obj).OnPropertyChanged("MyProperty");
      }
    }
