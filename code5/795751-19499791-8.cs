    public object FooObject { get; set; } // Implement INotifyPropertyChanged
    public int Foo
    {
        get { return FooObject.GetType() == typeof(int) ? int.Parse(FooObject) : -1; }
    }
