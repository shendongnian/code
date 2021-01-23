    private SomeViewModel _viewModel;
    public static readonly DependencyProperty MyStringProperty = DependencyProperty.Register("MyString", typeof(string), typeof(MyStringUserControl), new PropertyMetadata(OnMyStringChanged));
    public MyStringUserControl()
    {
        InitializeComponent();
        _viewModel = new SomeViewModel();
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        this.DataContext = _viewModel;
    }
    private static void OnMyStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MyStringUserControl)d).OnMyStringChanged(e.NewValue);
    }
    private void OnMyStringChanged(string newValue)
    {
        _viewModel.SomeProperty = newValue;
    }
    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "SomeProperty":
                SetValue(MyStringProperty, _viewModel.SomeProperty);
                break;
            default:
                break;
        }
    }
