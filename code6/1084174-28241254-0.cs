    public MainWindow()
    {
        InitializeComponent();
        
        BottomBrush.SetValue(SolidColorBrush.ColorProperty,
            Activator.CreateInstance(Type.GetType("System.Windows.ResourceReferenceExpression, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"), "MyColor"));
    
        Resources["MyColor"] = Colors.Green;
    }
