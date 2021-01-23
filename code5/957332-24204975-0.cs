     // Constructor
    public MainPage()
    {
        InitializeComponent();
        ListVerticalOffsetProperty = DependencyProperty.Register("ListVerticalOffset", typeof(double), typeof(MainPage), new PropertyMetadata(OnListVerticalOffsetChanged));
        YourScrollViewer.Loaded += YourScrollViewer_Loaded;
    }
    void YourScrollViewer_Loaded(object sender, RoutedEventArgs e)
    {
        var binding = new Binding
            {
                Source = YourScrollViewer,
                Path = new PropertyPath("VerticalOffset"),
                Mode = BindingMode.OneWay
            };
        SetBinding(ListVerticalOffsetProperty, binding);
    }
    private void OnListVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var atBottom = YourScrollViewer.VerticalOffset >=   YourScrollViewer.ScrollableHeight;
        if (atBottom) MessageBox.Show("End");
    }
    public readonly DependencyProperty ListVerticalOffsetProperty;
    public double ListVerticalOffset
    {
        get { return (double)GetValue(ListVerticalOffsetProperty); }
        set { SetValue(ListVerticalOffsetProperty, value); }
    }
