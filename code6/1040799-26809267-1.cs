        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
            var storageService = Container.Get<ISettingsService>();
            if (storageService.IsFirstRun())
            {
                storageService.Initialize();
            }
        }
