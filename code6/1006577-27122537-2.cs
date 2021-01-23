    private static LicenseInformation licenseInformation=null;
    public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
            
    #if DEBUG
            licenseInformation = CurrentAppSimulator.LicenseInformation;
    #else
            licenseInformation = CurrentApp.LicenseInformation; 
    #endif
            licenseInformation.LicenseChanged += licenseInformation_LicenseChanged;            
        }
