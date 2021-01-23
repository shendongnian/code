    private bool isVisible;
    public bool IsVisible
    {
       get { return isVisible;}
       set
       {
          if(isVisible != value)
          {
             isVisible = value;
             RaisePropertyChanged("IsVisible");
          }
       }
    }
