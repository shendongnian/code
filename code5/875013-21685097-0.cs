    SomeViewModel vm;
    public SomeView()
    {
        InitializeComponent();
        vm = new SomeViewModel(ForeColor);
        this.DataContext = vm;
    }
