        public Form1()
        {
            InitializeComponent();
            string requestedControl = QueryDatabase();
            AddControl(requestedControl);
        }
