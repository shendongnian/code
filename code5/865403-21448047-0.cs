    public MainPage()
            {
                InitializeComponent();
                
                this.Loaded += new RoutedEventHandler(DisplayMessage);
            }
    void DisplayMessage(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(ContentPanel.ActualHeight.ToString());
            }
