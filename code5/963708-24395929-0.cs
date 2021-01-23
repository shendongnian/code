    public SomePage()
    {
        this.InitializeComponent();
        this.Loaded += SomePage_Loaded;
    }
    
    void SomePage_Loaded(object sender, RoutedEventArgs e)
    {
        AddInformation();
    }
