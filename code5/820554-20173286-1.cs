    public MainWindow()
    {
        InitializeComponent();
        var prototype = new Prototype();
        Content = prototype;
        prototype.DoSomething();
    }
