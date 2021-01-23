     public Page2(Visibility visibilty)
        {
            InitializeComponent();
            DataContext = new ButtonViewModel(visibilty);
        }
        public Page2()
        {
            InitializeComponent();
            DataContext = new ButtonViewModel(Visibility.Visible);
        }
