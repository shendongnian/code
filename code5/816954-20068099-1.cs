    public static bool IsDesignMode(Control control)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)  // Initial quick check.
        {
            return true;
        }
        while (control != null)
        {
            System.ComponentModel.ISite site = control.Site;
            if ((site != null) && (site.DesignMode))
                return true;
            control = control.Parent;
        }
        return false;
    }
