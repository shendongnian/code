        private static BitmapImage first;
        private static BitmapImage second;
        private static ImageBrush backBrush;
    
        public MainPage()
        {
            this.InitializeComponent();
            first = new BitmapImage(new Uri("ms-appx:///Assets/Test.jpg"));
            second = new BitmapImage(new Uri("ms-appx:///Assets/NewBackground.jpg"));
            
            backBrush = new ImageBrush();
            SetBackground();
        }
    
        private void SetBackground()
        {
            if(backBrush.ImageSource == first)
            {
                backBrush.ImageSource = second;
            }
            else
            {
                backBrush.ImageSource = first;
            }
    
            MyParentGrid.Background = backBrush;
        }
    
        private void Personalize_Click(object sender, RoutedEventArgs e)
        {
            SetBackground();
        }
