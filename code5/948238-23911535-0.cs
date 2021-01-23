    public bool Foo
    {
        get { return _foo; }
        set
        {
            _foo = value;
            OnPropertyChanged("Foo");
            OnPropertyChanged("Baz");
        }
    }
    public bool Bar
    {
        get { return _bar; }
        set
        {
            _bar = value;
            OnPropertyChanged("Bar");
            OnPropertyChanged("Baz");
        }
    }
    public bool Baz
    {
        get
        {
            return Foo && Bar;
        }
    }
