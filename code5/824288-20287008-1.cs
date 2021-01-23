    protected virtual void OnPropertyChanged([CallerMemberName] string caller = null)
    {
        var handler = PropertyChanged;
        if(handler != null) handler(this, new PropertyChangedEventArgs(caller));
    }
    ...
    public int Foo {
        get { return foo; }
        set { this.foo = value; OnPropertyChanged(); }
    }
    public string Bar {
        get { return bar; }
        set { this.bar = value; OnPropertyChanged(); }
    }
    
