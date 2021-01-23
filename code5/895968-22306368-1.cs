    public MyRadioSelection UserSelection
    {
       get {return Model.GlobalSelection;}
       set
       {
           Model.GlobalSelection = value;
           OnPropertyChanged(UserSelection);
       }
    }
