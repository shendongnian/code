    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), 
        new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(
            CultureInfo.CurrentCulture.IetfLanguageTag)));
