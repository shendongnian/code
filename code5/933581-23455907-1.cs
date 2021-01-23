    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {   
            // Thread settings are separate and optional  
            // affect Parse and ToString:       
            // Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");
            // affect resource loading:
            // Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");
            FrameworkElement.LanguageProperty.OverrideMetadata(
                  typeof(FrameworkElement),
                  new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(
                              CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }
