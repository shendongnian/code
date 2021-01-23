    public interface ISettings
    {
        public bool IsTrial { get; }
    }
    public class Settings : ISettings
    {
        public bool IsTrial { get; set; }
    }
    public interface IRequiresSettings 
    {
        public ISettings { set; }
    }
    public class SomePage : PhoneApplicationPage, IRequiresSettings 
    {
        public ISettings Settings { get; set; }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
          Debug.WriteLine("DoThis- OnNavigatedTo");
          if( Settings != null && Settings.IsTrial )
          {
             // disable some functionality because trial mode...
          }
        }
    }
