    public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel.Instance;
            ViewModel.Instance.vlan=new ObservableCollection<string> { "Fred", "Theo", "Lil Kitty" };
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Instance.vlan.Add(String.Format("String {0}", ViewModel.Instance.vlan.Count + 1));
            Window1 win = new Window1();
            win.Show();
        }
