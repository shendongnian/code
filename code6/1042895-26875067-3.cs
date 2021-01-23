    public SetGetAccValues()
    {
        InitializeComponent();
    
        this.DataContextChanged += OnDataContextChanged;
                      
        this.DataContext = this;    
    }
    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        Y = ((double)(sbyte)value) / 64.0;
        Y = Math.Round(Y, 2);
    
        (dependencyPropertyChangedEventArgs.NewValue as SetGetAccValues).xValue = Y.ToString();
    }
