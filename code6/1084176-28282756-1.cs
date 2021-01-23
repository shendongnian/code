      public MainWindow() {
         InitializeComponent();
         var key = TopBrush.GetDynamicResourceKey(SolidColorBrush.ColorProperty);
         BottomBrush.SetDynamicResourceKey(SolidColorBrush.ColorProperty, key);
         Resources["MyColor"] = Colors.Green;
      }
