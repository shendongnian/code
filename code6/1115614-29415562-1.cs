     public MainWindow()
            {
                InitializeComponent();
                DataContext = new TestViewModel();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                PredictionsPopup.Placement = PlacementMode.MousePoint;
                PredictionsPopup.IsOpen = true;
    
            }
