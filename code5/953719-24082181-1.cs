        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            //  HardwareButtons.BackPressed += HardwareButtons_BackPressed; // this line also could fire Frame.GoBack() (as default project template)
            // of course check what is in the above method
        }
