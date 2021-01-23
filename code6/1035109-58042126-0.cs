    public bool MyProperty
    {
        get { return (bool) GetValue(MyPropertyProperty); }
        set { 
                  SetValue(MyPropertyProperty, value); 
                  OnPropertyChanged("MyProperty"); 
            }
    }
