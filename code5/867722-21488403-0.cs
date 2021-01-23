    public interface ISettings
    {
        public bool IsTrial { get; }
    }
    public interface IRequiresSettings 
    {
        public ISettings { set; }
    }
    public class SomePage : Page, IRequiresSettings 
    {
        public ISettings Settings { get; set; }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
          Debug.WriteLine("DoThis- OnNavigatedTo");
          if( Settings.IsTrial )
          {
             // disable some functionality because trial mode...
          }
        }
    }
