    private MyView _ObjMyViewModel;
    public MyView ObjMyViewModel
    {
        get { return _ObjMyViewModel; }
        set
        {
            _ObjMyViewModel= value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ObjMyViewModel"));
        }
    }
