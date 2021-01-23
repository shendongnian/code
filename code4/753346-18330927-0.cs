        public MainWindow()
        {
          InitializeComponent();
          this.PreviewKeyUp += MainWindow_PreviewKeyUp;
    
        }
    
        void MainWindow_PreviewKeyUp(object sender, KeyEventArgs e)
        {
          if (e.Key == Key.Apps)
          {
            e.Handled = true;
          }
        }
