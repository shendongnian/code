    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyItems = new ObservableCollection<ComboBoxItem>();
            MyItems.Add(new ComboBoxItem
            {
                Name = "PhoneItem_" + DateTime.Now.Second,
                Content = string.Format("Phone: {0}", "123"),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center
            });
        }
        public ObservableCollection<ComboBoxItem> MyItems { get; set; }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyItems.Add(new ComboBoxItem
            {
                Name = "PhoneItem_" + DateTime.Now.Second,
                Content = string.Format("Phone: {0}", "123"),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center
            });
        }
    }
