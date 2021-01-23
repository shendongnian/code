    // settings class that the Pages will get access to
    public interface ISettings
    {
        public bool IsTrial { get; }
    }
    // implementation of ISettings -- owned by the App class
    public class Settings : ISettings
    {
        public bool IsTrial { get; set; }
    }
    // interface that a Page should inherit if it needs access to IsTrial
    public interface IRequiresSettings 
    {
        public ISettings { set; }
    }
    public class SomePage : PhoneApplicationPage, IRequiresSettings 
    {
        public ISettings Settings { get; set; }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
          if( Settings != null && Settings.IsTrial )
          {
             // disable some functionality because trial mode...
          }
        }
    }
