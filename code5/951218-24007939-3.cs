         public MainWindow()
         {
            InitializeComponent();
            Buttons = ObservableCollection<string>();
            DataContext = this;
         }
    private void btn_groupname_Click(object sender, RoutedEventArgs e)
    {
        if (ButtonName != string.Empty)
        {
                Buttons.Add(ButtonName);
               ButtonName = string.Empty;
        }            
    }
