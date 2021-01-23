    public MobilityWelcome()
        {
            InitializeComponent();
            mobilityWelcomeViewModel = new mobilityWelcomeViewModel();
            this.DataContext = this.mobilityWelcomeViewModel;
        }
