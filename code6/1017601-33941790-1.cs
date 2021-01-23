        public LaunchPadPage() {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            this.Loaded += LaunchPadPage_Loaded;
            this.app = (App)App.Current;
        }
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e) {
            // Let's show the root zone items
            // NB: In case we don't have this data yet, do nothing
            if (app.Hierarchy != null)
            {
                DefaultViewModel["Items"] = app.Hierarchy.RootItems;
            }
        }
        private void LaunchPadPage_Loaded(object sender, RoutedEventArgs e) {
            // No data? Go to the downloads page instead.
            if (app.Hierarchy == null)
            {
                Frame.Navigate(typeof(DownloadingPage));
            }
        }
