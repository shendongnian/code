        public App()
        {
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = Windows.System.UserProfile.GlobalizationPreferences.HomeGeographicRegion;
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }
