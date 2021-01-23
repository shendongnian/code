        public MainWindow()
        {
            InitializeComponent();
            ScalableTextBox tb = new ScalableTextBox();
            tb.Width = 140;
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("./left.png", UriKind.Relative);
            src.EndInit();
            tb.LeftImage.Source = src;
            src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("./center.png", UriKind.Relative);
            src.EndInit();
            tb.CenterImage.Source = src;
            src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("./right.png", UriKind.Relative);
            src.EndInit();
            tb.RightImage.Source = src;
            Grid.SetRow(tb, 0);
            Grid.SetColumn(tb, 0);
            myGrid.Children.Add(tb);
        }
