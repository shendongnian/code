    private override void OnPropertyChanged(string PropertyName)
    {
       base.OnPropertyChanged(PropertyName);
       switch (PropertyName)
       {
          case "IsEnabled":
              OnPropertyChanged("ToggleCursor");
              break;
       }
    }
