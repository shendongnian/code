    private static readonly DependencyPropertyKey MyCalculatedPropertyPropertyKey =
        DependencyProperty.RegisterReadOnly("MyCalculatedProperty", typeof(int), typeof(MyControl),
        new PropertyMetadata(int.MinValue));
    public static readonly DependencyProperty MyCalculatedPropertyProperty = MyCalculatedPropertyPropertyKey.DependencyProperty;
    public int MyCalculatedProperty
    {
        get { return (int)GetValue(MyCalculatedPropertyProperty); }
        private set { SetValue(MyCalculatedPropertyPropertyKey, value); }
    }
    private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MyControl)d).MyCalculatedProperty = (int)e.NewValue;
    }
    public MyControl()
        : base()
    {
        InitializeComponent();
        MyCalculatedProperty = GetDefaultPropertyValue();
    }
