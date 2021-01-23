    // the binding should work
    public StringList Stuff { get; set; }
    public Constructor()
    {
        Stuff = new StringList { "blah", "blah", "foo", "bar" };
        InitializeComponent();
    }
    // the binding won't work
    public StringList Stuff { get; set; }
    public Constructor()
    {
        InitializeComponent();
        Stuff = new StringList { "blah", "blah", "foo", "bar" };
    }
