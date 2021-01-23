            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
    
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                uiList.Items.Add("Looooooooooooong text 1");
                uiList.Items.Add("Normal text 2");
                uiList.Items.Add("Short 3");
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                uiList.Items.Add("text 4");
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (uiList.Items.Count > 0)
                {
                    uiList.Items.RemoveAt(0);
                }
            }
