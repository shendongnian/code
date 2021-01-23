      // Constructor
        public MainPage()
        {
            InitializeComponent();
            BindStreams();
        }
    private void BindStreams()
        {
            lstStreams.ItemsSource = new List<StreamType>
                {
                    new StreamType { Description = "Description One", Title = "Title One"},
                    new StreamType { Description = "Description Two", Title = "Title Two"},
                    new StreamType { Description = "Description Three", Title = "Title Three"},
                };
        }
