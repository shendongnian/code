    public MainWindow()
    {
        InitializeComponent();
            
        Sa.Stroke = System.Windows.Media.Brushes.Black;
        Slid1.ValueChanged += Slid1_ValueChanged;           
    }
    void Slid1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {            
        Sa.X1 = slider.Value;
        Sa.X2 = window.Width / 2;
        Sa.Y1 = (window.Height) / 2;
        Sa.Y2 = window.Height / 2 - 50;
    }
