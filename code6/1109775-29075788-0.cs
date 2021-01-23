        public App()
        {
			// Override to english
			ApplicationLanguages.PrimaryLanguageOverride = "en";
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
