    public MainWindow()
    {
        InitializeComponent();
        DataContext = new Student();
    }
    private void Clear_Clicked(object sender, RoutedEventArgs e)
    {
        ((Student)DataContext).FirstName = string.Empty;
    }
