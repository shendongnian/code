        public static readonly DependencyProperty ItemsProperty
            = DependencyProperty.Register("Items", typeof (IEnumerable<string>), typeof (MainWindow));
        public IEnumerable<string> Items
        {
            get { return (IEnumerable<string>) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Items = new[] {"sdf", "fdsa", "tgrg"};
        }
