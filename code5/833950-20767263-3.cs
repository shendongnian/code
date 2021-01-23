        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            YourPclLibrary.ApplicationName = "MyBeautifulSoup";
            // etc...
        }
