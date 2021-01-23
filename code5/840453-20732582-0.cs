    Private Visibility _vis_UC_2;
    Public Visibility vis_UC2
    {
    get
    {
       return _vis_UC2;
    }
    set
    {
       _vis_UC2 = value;
       OnPropertyChanged("vis_UC2");
    }
    }
