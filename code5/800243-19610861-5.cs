    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Messenger.Default.Send(System.Windows.Visibility.Visible, "UserCredentialsVisible");
            Messenger.Default.Send(System.Windows.Visibility.Visible, "BrowserSelectionVisible");
        }
    }
