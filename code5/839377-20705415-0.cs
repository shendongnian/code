    public MainControl()
    {
        InitializeComponent();
        DataContextChanged += MainControl_DataContextChanged;
    }
    void MainControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        lblCountCars.Content = string.Format("there is {0} cars.", Repository.CountAllCars());    
    }
        
