    using System.ComponentModel;    
    public MyControl()
    {
        // code that Designer should run
        if (LicenseManager.UsageMode == LicenseUsageMode.DesignTime)
            return;
        // code that Designer should not run
    }
