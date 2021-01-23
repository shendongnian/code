    public MainWindow()
    {
        InitializeComponent();
        // We can access ListViewPeople here because that's the Name of our list
        // using the x:Name property in the designer.
        ListViewPeople.ItemsSource = ReadCSV("example");
    }
