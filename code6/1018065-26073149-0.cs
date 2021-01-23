    public AddressControl()
    {
        InitializeComponent();
        this.Loaded += AddressControl_Loaded;
    }
    void AddressControl_Loaded(object sender, RoutedEventArgs e)
    {
        var parentGrid = this.Parent as Grid;
        if (parentGrid != null)
        {
            var width = Math.Max(this.Col1.ActualWidth, parentGrid.ColumnDefinitions[0].ActualWidth);
            this.Col1.Width = new GridLength(width);
            parentGrid.ColumnDefinitions[0].Width = new GridLength(width);
        }
    }
