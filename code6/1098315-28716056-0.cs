    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1),new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
        public override void OnApplyTemplate()
        {
              base.OnApplyTemplate();
              DataContext = ((MyLocatorType)Resources["Locator"]).SplashMainViewModel;
        }
    }
