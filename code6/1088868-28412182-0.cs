    protected override void InitializeCulture()
    {
        Page.Culture = "French"
        Page.UICulture = "fr";
        
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("fr");
        System.Threading.Thread.CurrentThread.CurrentUICulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
    }
