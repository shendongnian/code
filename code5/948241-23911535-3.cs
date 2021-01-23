    public bool Foo
    {
        get { return _foo; }
        set { _foo = value; OnPropertyChanged("Foo"); }
    }
    public bool Bar
    {
        get { return _bar; }
        set { _bar = value; OnPropertyChanged("Bar"); }
    }
